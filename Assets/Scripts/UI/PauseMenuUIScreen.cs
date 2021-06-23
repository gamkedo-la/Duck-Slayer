using UnityEngine;
using Events;

public class PauseMenuUIScreen : MonoBehaviour
{
    [SerializeField] private GameEvent pauseGameEvent;
    [SerializeField] private GameEvent unpauseGameEvent;
    [SerializeField] private GameObject uiScreen;
    private bool lastIsPausedValue;

    public void Start()
    {
        LogInvalidState();
        // by default, we want to disable the pause menu
        uiScreen.SetActive(false); 
    }

    public void Update()
    {
        // this logic could be replaced by hooking into state changes
        // of the GameEvent scriptable objects.
        if(lastIsPausedValue != GameManagerSingleton.instance.IsPaused())
        {
            lastIsPausedValue = GameManagerSingleton.instance.IsPaused();
            ToggleScreen(showScreen: lastIsPausedValue, invokeEvent: false);
        }
    }

    // this method is meant to be connected to the UI button onClick action via the inspector
    public void HandleResumeButtonPress()
    {
        ToggleScreen(showScreen: false, invokeEvent: true);
    }

    private void ToggleScreen(bool showScreen, bool invokeEvent)
    {
        uiScreen.SetActive(showScreen);
        if(invokeEvent)
        {
            if(showScreen) 
            {
                pauseGameEvent?.Invoke();
            }
            else
            {
                unpauseGameEvent?.Invoke();
            }
        }
    }

    private void LogInvalidState()
    {
        if(uiScreen == null)
        {
            Debug.LogError($"The screen field is not set in the gameobject named [{this.gameObject.name}]");
        }

        if(pauseGameEvent == null)
        {
            Debug.LogError($"The pause event field is not set in the gameobject named [{this.gameObject.name}]");
        }

        if(unpauseGameEvent == null)
        {
            Debug.LogError($"The unpause event field is not set in the gameobject named [{this.gameObject.name}]");
        }
    }
}
