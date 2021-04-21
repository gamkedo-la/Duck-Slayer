using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownRate;
	public float slowDownSeconds;

	private void Update()
	{
		Time.timeScale += (1f / slowDownSeconds) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
	}

	public void SlowDown()
	{
		Time.timeScale = slowDownRate;
		Time.fixedDeltaTime = Time.timeScale * Time.fixedDeltaTime / slowDownRate;
	}
}
