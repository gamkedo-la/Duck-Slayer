using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshPro Display;

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Your score is " + score);

        Display.text = "Score: " + score;
    }
}
