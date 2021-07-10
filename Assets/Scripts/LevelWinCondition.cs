using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinCondition : MonoBehaviour
{
    [SerializeField] IntVariable objective;
    [SerializeField] IntVariable trackedVariable;
    [SerializeField] GameEvent objectiveComplete;

    [SerializeField] bool hasCalledObjectiveCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (objective == null)
        {
            Debug.LogError("No objective set for this level, Disabling LevelWinCondition!", gameObject);
            enabled = false;
        }

        hasCalledObjectiveCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCalledObjectiveCompleted == false && trackedVariable.value >= objective.value)
        {
            objectiveComplete?.Invoke();
            hasCalledObjectiveCompleted = true;
        }
    }
}
