using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlowMotionOnActionInput : MonoBehaviour
{
    public InputActionReference SlowMotionButton;
    public GameObject gameManager;
    private SlowMotion slowMotionScript;

    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Start()
    {
        SlowMotionButton.action.performed += HandleSlowMotionButtonPress;
        slowMotionScript = GameManagerSingleton.instance.GetComponent<SlowMotion>();
    }

    void HandleSlowMotionButtonPress(InputAction.CallbackContext obj)
    {
        slowMotionScript.SlowDown();
        if(logDebug) Debug.Log("SlowMo Button Pressed!");
    }
}
