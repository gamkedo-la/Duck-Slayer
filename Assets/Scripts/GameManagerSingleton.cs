using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance;
    private Score scoreKeeper;
    private SlowMotion slowMotion;
    private BulletManager bulletManager;

    void Awake() {
      instance = this;
      scoreKeeper = GetComponent<Score>();
      slowMotion = GetComponent<SlowMotion>();
      bulletManager = GetComponent<BulletManager>();
    }

    public Score GetScore()
    {
      return scoreKeeper;
    }

    public SlowMotion GetSlowMotion()
    {
      return slowMotion;
    }

    public BulletManager GetBulletManager()
	{
      return bulletManager;
    }
}
