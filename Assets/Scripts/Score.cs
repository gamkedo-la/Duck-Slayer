using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshPro Display;

    public void IncreaseScore(float multiplier)
    {

        //Debug.Log("Target Score: " + multiplier);

        score += Mathf.RoundToInt(multiplier);
        //Debug.Log("Your score is " + score);

        Display.text = "Score: " + score;
    }
}
