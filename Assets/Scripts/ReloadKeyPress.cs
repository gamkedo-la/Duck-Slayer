using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class ReloadKeyPress : MonoBehaviour
{
    [SerializeField] GameEventTrigger reloadTrigger;
    [SerializeField] KeyCode reloadKey;

    void Update()
    {
        if (reloadTrigger == null) return;

        if (Input.GetKeyDown(reloadKey))
            reloadTrigger.TriggerEvent();
    }
}
