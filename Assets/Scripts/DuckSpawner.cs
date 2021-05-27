using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject[] DuckPrefab;

    public BezierSpline[] AttackPaths;
    public BezierSpline[] PassivePaths;

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

    [Header("Destroy Duck At end of Path")]
    [SerializeField] IntVariable DucksSpawned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            thisSpline = AttackPaths[Random.Range(0, AttackPaths.Length)];
        }
        else
        {
            thisSpline = PassivePaths[Random.Range(0, PassivePaths.Length)];
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
