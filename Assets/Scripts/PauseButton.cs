using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Events;

public class PauseButton : ButtonAction
{
    public GameEvent unPause;
    private bool isPaused = false;
    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Awake()
    {
        Debug.Log($"Debug Log value is [{logDebug}] in [{this.gameObject.name}:{this.GetType().Name}]]");
    }
    
    override public void HandleButtonPress(InputAction.CallbackContext obj)
    {
        isPaused = GameManagerSingleton.instance.IsPaused();

        if(logDebug) Debug.Log("Game paused: " + isPaused, gameObject);

        if (isPaused)
        {
            unPause?.Invoke();
            return;
        }

        gameEvent?.Invoke();
    }
}
