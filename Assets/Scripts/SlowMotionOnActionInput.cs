using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlowMotionOnActionInput : MonoBehaviour
{
    public InputActionReference SlowMotionButton;
    public GameObject gameManager;
    private SlowMotion slowMotionScript;
    // Start is called before the first frame update
    void Start()
    {
        SlowMotionButton.action.performed += HandleSlowMotionButtonPress;
        slowMotionScript = GameManagerSingleton.instance.GetComponent<SlowMotion>();
    }

    void HandleSlowMotionButtonPress(InputAction.CallbackContext obj)
    {
        slowMotionScript.SlowDown();
        Debug.Log("SlowMo Button Pressed!");
    }
}
