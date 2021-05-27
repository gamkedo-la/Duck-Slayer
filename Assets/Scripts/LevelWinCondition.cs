using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinCondition : MonoBehaviour
{
    [SerializeField] IntVariable objective;
    [SerializeField] IntVariable trackedVariable;
    [SerializeField] GameEvent objectiveComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (objective == null)
        {
            Debug.LogError("No objective set for this level, Disabling LevelWinCondition!", gameObject);
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trackedVariable.value >= objective.value)
            objectiveComplete?.Invoke();
    }
}
