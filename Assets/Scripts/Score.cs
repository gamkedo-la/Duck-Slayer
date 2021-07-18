using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshPro Display;
    public int CurrentScore => TrackedScore.value;
    [SerializeField] private IntVariable TrackedScore;

    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Awake()
    {
        Debug.Log($"Debug Log value is [{logDebug}] in [{this.gameObject.name}:{this.GetType().Name}]]");
    }
    public void IncreaseScore(float multiplier)
    {
        SetScore(TrackedScore.value + Mathf.RoundToInt(multiplier));
    }

    public void Reset()
    {
        SetScore(0);
    }

    public void SetScore(int value)
    {
        TrackedScore.value = value;
        Display.text = "Score: " + value;
        if(logDebug) Debug.Log($"adding [{value}] total score[{TrackedScore.value}]");
    }
}
