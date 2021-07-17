using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshPro Display;
    [SerializeField] private IntVariable TrackedScore;
    public int CurrentScore => TrackedScore.value;

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
        Debug.Log($"adding [{value}] total score[{TrackedScore.value}]");
        Display.text = "Score: " + value;
    }
}
