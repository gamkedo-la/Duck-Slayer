using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinCondition : MonoBehaviour
{
    [SerializeField] GameEvent objectiveComplete;

    [SerializeField] bool hasCalledObjectiveCompleted = false;

    private Score scoreKeeper;
    private LevelConfiguration currentConfiguration;

    private void Start()
    {
        hasCalledObjectiveCompleted = false;
    }

    private void Update()
    {
        if(scoreKeeper == null || currentConfiguration == null)
        {
            return;
        }

        if (hasCalledObjectiveCompleted == false && scoreKeeper.CurrentScore >= currentConfiguration.WinScore)
        {
            Debug.Log($"Objective Completed! trackedVar:[{scoreKeeper.CurrentScore}] objective:[{currentConfiguration.WinScore}]");
            objectiveComplete?.Invoke();
            hasCalledObjectiveCompleted = true;
        }
    }

    public void ResetWinCondition()
    {
        Debug.Log("Resetting Win Condition");
        hasCalledObjectiveCompleted = false;
    }

    public void SetScoreKeeper(Score value)
    {
        this.scoreKeeper = value;
    }

    public void SetLevelConfiguration(LevelConfiguration levelConfig)
    {
        this.currentConfiguration = levelConfig;
    }
}
