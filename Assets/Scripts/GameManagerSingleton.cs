using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;
using GM = GameManagerSingleton;

public enum GameState { Start, Pause, Play, GameOver }
public class GameManagerSingleton : MonoBehaviour
{

    public static GameManagerSingleton instance;
    private Score scoreKeeper;
    private SlowMotion slowMotion;
    private BulletManager bulletManager;
    private DuckSpawner duckSpawner;
    private DifficultyProgression difficultyProgression;

    [SerializeField] private GameState gameState;
    [SerializeField] private GameEvent gameStartEvent;
    [SerializeField] private GameEvent worldCompleteEvent;

    void Awake()
    {
        instance = this;
        scoreKeeper = GetComponent<Score>();
        slowMotion = GetComponent<SlowMotion>();
        bulletManager = GetComponent<BulletManager>();
        //WorldSetup();
    }

    public void WorldSetup()
    {
        GM.instance.duckSpawner = GameObject.FindObjectOfType<DuckSpawner>();
        GM.instance.difficultyProgression = GameObject.FindObjectOfType<DifficultyProgression>();
        LoadNextDifficultyLevel();
    }

    public void LoadNextDifficultyLevel()
    {
      if(GM.instance.duckSpawner == null)
      {
        Debug.LogError("duckSpawner == null");
        return;
      }

      if(GM.instance.difficultyProgression == null)
      {
        Debug.LogError("difficultyProgression == null");
        return;
      }

      LevelConfiguration level;

      int currentDifficultyIndex = GM.instance.difficultyProgression.GetCurrentIndex();
      if (GM.instance.difficultyProgression.HasNextLevel(currentDifficultyIndex, out level))
      {
        GM.instance.difficultyProgression.SetCurrentIndex(currentDifficultyIndex + 1);
        GM.instance.duckSpawner.InitalizeDuckSpawner(level);
        GM.instance.duckSpawner.SetIsGameStarted(true);
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
      if(Input.GetKeyDown(KeyCode.L))
      {
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
}
