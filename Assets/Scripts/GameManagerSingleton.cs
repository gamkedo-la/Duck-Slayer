using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance;
    private Score scoreKeeper;
    private SlowMotion slowMotion;

    void Awake() {
      instance = this;
      scoreKeeper = GetComponent<Score>();
      slowMotion = GetComponent<SlowMotion>();
    }

    public Score GetScore()
    {
      return scoreKeeper;
    }

    public SlowMotion GetSlowMotion()
    {
      return slowMotion;
    }
}
