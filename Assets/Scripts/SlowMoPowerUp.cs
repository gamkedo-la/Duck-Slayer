using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoPowerUp : PowerUp
{
    public override void TriggerPower(float amount)
    {
        var slowMoManager = GameObject.FindObjectOfType<SlowMotion>();
        if(slowMoManager != null)
        {
            slowMoManager.SlowDown();
        }
    }
}
