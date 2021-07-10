using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public enum PrefabType { Duck, Car };
    [SerializeField] PrefabType _spawnerType = PrefabType.Duck;
    [SerializeField] LevelConfiguration DefaultConfiguration;
    public GameObject[] DuckPrefab;

    public BezierSpline[] AttackPaths;
    public BezierSpline[] PassivePaths;

    private int AttackPathIndexLimit;
    private int PassivePathIndexLimit;

    private int weight;

    [Header("Edit the probabilties of aggressive or passive duck spawns")]
    public int AttackWeight;
    public int PassiveWeight;

    [Header("Time between ducks")]
    public float minSpawnTime;
    public float maxSpawnTime;

    [Header("Delay before first duck spawns")]
    public float Timer;

    [Header("Time it takes for each duck to complete its path")]
    public float DuckMinFlightTime;
    public float DuckMaxFlightTime;

    [Header("Destroy Duck At end of Path")]
    public bool DestroyAtEndOfPath;

    [Header("Game Variables")]
    [SerializeField] IntVariable DucksSpawned;
    [SerializeField] TransformRef PlayerTransform;
    [SerializeField] [Range(0, 100)] float DiveBombProbability;

    private bool isGameStarted = false;
    public PrefabType SpawnerType => _spawnerType;

    public void SetIsGameStarted(bool IsStarted)
    {
      isGameStarted = IsStarted;
    }

    void Start() {
      // InitalizeDuckSpawner(DefaultConfiguration);
      if(SpawnerType == PrefabType.Car)
      {
        Debug.Log($"Spawner type is [{SpawnerType}], calling SetIsGameStarted function from Start function in [{this.name}] in gameobject [{this.gameObject.name}]");
        SetIsGameStarted(true);
      }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted == false) return;

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            GameObject D;
            BezierSpline thisSpline;

            SpawnDuck(out D, out thisSpline);

            TellDuckToFly(D, thisSpline);

            Timer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    public void InitalizeDuckSpawner(LevelConfiguration LevelConfig)
    {
      if(DucksSpawned == null)
      {
          Debug.Log($"not assignment to [{this.gameObject.name}]");
      }

      DucksSpawned.Reset(); 
      if(LevelConfig == null)
      {
        Debug.LogError("LevelConfig == null");
        return;
      }
      DuckPrefab = LevelConfig.DuckPrefab;
      AttackPathIndexLimit = LevelConfig.AttackPathIndexLimit;
      PassivePathIndexLimit = LevelConfig.PassivePathIndexLimit;
      AttackWeight = LevelConfig.AttackWeight;
      PassiveWeight = LevelConfig.PassiveWeight;
      minSpawnTime = LevelConfig.minSpawnTime;
      maxSpawnTime = LevelConfig.maxSpawnTime;
      Timer = LevelConfig.Timer;
      DuckMinFlightTime = LevelConfig.DuckMinFlightTime;
      DuckMaxFlightTime = LevelConfig.DuckMaxFlightTime;
      DiveBombProbability = LevelConfig.DiveBombProbability;
    }

    private void SpawnDuck(out GameObject D, out BezierSpline thisSpline)
    {
        var randomIndex = Random.Range(0, DuckPrefab.Length);

        IncrementSpawnCounter();

        D = Instantiate(DuckPrefab[randomIndex]);
        D.transform.parent = transform;

        thisSpline = null;
        weight = Random.Range(1, AttackWeight + PassiveWeight + 1);

        if (weight <= AttackWeight)
        {
            thisSpline = AttackPaths[Random.Range(0, AttackPathIndexLimit)];
            //thisSpline = AttackPaths[Random.Range(0, AttackPaths.Length)];
        }
        else
        {
            thisSpline = PassivePaths[Random.Range(0, PassivePaths.Length)];
        }

        var isDiveBomber = D.GetComponent<DiveBomber>();

        if (isDiveBomber)
        {
            isDiveBomber.RollForDiveBomb(DiveBombProbability);
            isDiveBomber.SetPlayerTarget(PlayerTransform.value.position);
        }
    }

    private void IncrementSpawnCounter()
    {
        if (DucksSpawned != null)
            ++DucksSpawned.value;
    }

    private void TellDuckToFly(GameObject D, BezierSpline thisSpline)
    {
        var pathFollowSettings = D.GetComponent<PathFollower>();
        var duckFlightTime = Random.Range(DuckMinFlightTime, DuckMaxFlightTime);

        pathFollowSettings.spline = thisSpline;
        pathFollowSettings.duration = duckFlightTime;
        pathFollowSettings.lookForward = true;
        pathFollowSettings.mode = PathFollowMode.Once;
        pathFollowSettings.destroyAtEndOfPath = DestroyAtEndOfPath;
    }

    private void OnDestroy()
    {
        if (DucksSpawned != null)
            DucksSpawned.Reset();
    }
}
