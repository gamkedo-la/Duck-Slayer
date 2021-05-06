using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var bulletManager = GameManagerSingleton.instance.GetBulletManager();
        bulletManager.Reload();
        gameObject.SetActive(false);
    }
}
