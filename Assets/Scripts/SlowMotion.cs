using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownRate;
    public float slowDownDurantionInSeconds;
    public float restoreSlowdownInSeconds;
    private bool isInSlowMo = false;
    private float slowdownElapsedTime;

    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(logDebug) Debug.Log("activating SlowMo!");
            SlowDown();
        }

        if (isInSlowMo && !GameManagerSingleton.instance.IsPaused())
        {
            if(slowdownElapsedTime > slowDownDurantionInSeconds)
            {
                RestoreTimeSpeed();
            } 
            else
            {
                slowdownElapsedTime += Time.unscaledDeltaTime;
            }
        }
    }

    private void RestoreTimeSpeed()
    {
        Time.timeScale += (1f / restoreSlowdownInSeconds) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Time.timeScale == 1)
        {
            isInSlowMo = false;
        }
    }

    public void SlowDown()
    {
        isInSlowMo = true;
        slowdownElapsedTime = 0f;

        Time.timeScale = slowDownRate;
        var fixedDeltaTimeSlowRate = Time.timeScale * Time.fixedDeltaTime / slowDownRate;
        Time.fixedDeltaTime = fixedDeltaTimeSlowRate;
        
        if(logDebug) Debug.Log($"Slowing down from [{this.gameObject.name}] at a rate of [{slowDownRate}] and [{fixedDeltaTimeSlowRate}]");
    }
}
