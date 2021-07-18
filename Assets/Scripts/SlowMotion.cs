using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownRate;
    public float slowDownSeconds;
    private bool isInSlowMo = false;

    private void Update()
    {
        if (isInSlowMo && !GameManagerSingleton.instance.IsPaused())
        {
            RestoreTimeSpeed();
        }
    }

    private void RestoreTimeSpeed()
    {
        Time.timeScale += (1f / slowDownSeconds) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1)
        {
            isInSlowMo = false;
        }
    }

    public void SlowDown()
    {
        isInSlowMo = true;
        Time.timeScale = slowDownRate;
        Time.fixedDeltaTime = Time.timeScale * Time.fixedDeltaTime / slowDownRate;
    }
}
