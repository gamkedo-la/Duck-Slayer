using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    private void OnEnable()
    {
        BroadcastMessage("InitializeAudioSource");
    }

    private void OnTriggerEnter(Collider other)
    {
        var bulletManager = GameManagerSingleton.instance.GetBulletManager();
        bulletManager.Reload();
        BroadcastMessage("PlayAudio");
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
