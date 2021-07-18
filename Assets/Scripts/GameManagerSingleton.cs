using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using GM = GameManagerSingleton;

public enum GameState { Start, Pause, Play, GameOver }
[RequireComponent(typeof(LevelWinCondition))]
public class GameManagerSingleton : MonoBehaviour
{

    public static GameManagerSingleton instance;
    private Score scoreKeeper;
    private SlowMotion slowMotion;
    private BulletManager bulletManager;
    private DuckSpawner duckSpawner;
    private DifficultyProgression difficultyProgression;
    private LevelWinCondition levelWinCondition;
    private Transform playerTransform;

    [SerializeField] private GameState gameState;
    [SerializeField] private GameEvent gameStartEvent;
    [SerializeField] private GameEvent worldCompleteEvent;

    [Header("Score Range Config")]
    [SerializeField] private float midRangeStartDistance;
    [SerializeField] private float midRangeEndDistance;

    void Awake()
    {
        instance = this;
        scoreKeeper = GetComponent<Score>();
        slowMotion = GetComponent<SlowMotion>();
        bulletManager = GetComponent<BulletManager>();
        //WorldSetup();
        GetScore().Reset(); // resets score when game restarts


        levelWinCondition = GetComponent<LevelWinCondition>();
        if (levelWinCondition == null)
        {
            Debug.LogError($"The gameobject [{this.gameObject.name}] does not have a level win condition");
        }
    }

    public void WorldSetup()
    {
        GM.instance.duckSpawner = GetDuckSpawner();
        if (GM.instance.duckSpawner == null)
        {
            Debug.LogError($"No Duck Spawner found at [{this.gameObject.name}]");
        }

        GM.instance.difficultyProgression = GameObject.FindObjectOfType<DifficultyProgression>();

        LoadNextDifficultyLevel();
        levelWinCondition.SetScoreKeeper(GetScore());
    }

    public void LoadNextDifficultyLevel()
    {
        if (GM.instance.duckSpawner == null)
        {
            Debug.LogError("duckSpawner == null");
            return;
        }

        if (GM.instance.difficultyProgression == null)
        {
            Debug.LogError("difficultyProgression == null");
            return;
        }


        // resets score before moving onto next difficulty or level/scene
        // so that we can track the score and move to the next level
        GetScore().SetScore(0);

        // since there are multiple difficulties in one level, we must reset the win condition
        // after resetting the score
        levelWinCondition.ResetWinCondition();

        LevelConfiguration level;
        int currentDifficultyIndex = GM.instance.difficultyProgression.GetCurrentIndex();
        if (GM.instance.difficultyProgression.HasNextLevel(currentDifficultyIndex, out level))
        {
            Debug.Log($"Setting difficulty level to : [{level.name}] and current score is [{GetScore().CurrentScore}]");
            GM.instance.difficultyProgression.SetCurrentIndex(currentDifficultyIndex + 1);
            GM.instance.duckSpawner.InitalizeDuckSpawner(level);
            GM.instance.duckSpawner.SetIsGameStarted(true);
            levelWinCondition.SetLevelConfiguration(level);
            return;
        }

        worldCompleteEvent?.Invoke();
    }

    private void Start()
    {
        gameState = GameState.Play;
        gameStartEvent?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L key pressed");
            GM.instance.WorldSetup();
        }
    }

    public Score GetScore()
    {
        return scoreKeeper;
    }

    public SlowMotion GetSlowMotion()
    {
        return slowMotion;
    }

    public void Pause()
    {
        instance.gameState = GameState.Pause;
        Debug.Log("Paused Called");
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //Debug.Log("Resume Game");

        instance.gameState = GameState.Play;
        Time.timeScale = 1;
    }

    public bool IsPaused()
    {
        if (gameState == GameState.Pause)
        {
            return true;
        }
        return false;
    }

    public BulletManager GetBulletManager()
    {
        return bulletManager;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    public void SetPlayerTransform(Transform value)
    {
        this.playerTransform = value;
    }

    public HitRangeEnum GetHitRangeEnum(float distanceFromPlayer)
    {
        if(distanceFromPlayer < midRangeStartDistance)
        {
            return HitRangeEnum.Short;
        }

        if(distanceFromPlayer < midRangeEndDistance)
        {
            return HitRangeEnum.Mid;
        }

        return HitRangeEnum.Long;
    }

    private DuckSpawner GetDuckSpawner()
    {
        var allDuckSpawners = GameObject.FindObjectsOfType<DuckSpawner>();
        foreach (var spawner in allDuckSpawners)
        {
            if (spawner.SpawnerType == DuckSpawner.PrefabType.Duck)
            {
                return spawner;
            }
        }

        return null;
    }


}
