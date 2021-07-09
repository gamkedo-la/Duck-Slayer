using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Events;

public class PauseButton : ButtonAction
{
    public GameEvent unPause;
    private bool isPaused;

    private void Start()
    {
        isPaused = GameManagerSingleton.instance.IsPaused();
    }

    override public void HandleButtonPress(InputAction.CallbackContext obj)
    {
        isPaused = GameManagerSingleton.instance.IsPaused();

        Debug.Log("Game paused: " + isPaused, gameObject);

        if (isPaused)
        {
            unPause?.Invoke();
            return;
        }

        gameEvent?.Invoke();
    }
}
