using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    public void IncreaseScore()
	{
		score++;
		Debug.Log("Your score is " + score);
	}
}
