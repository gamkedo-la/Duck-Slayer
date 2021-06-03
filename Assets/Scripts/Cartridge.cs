using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public GameEvent reload;

    private void OnTriggerEnter(Collider other)
    {
        reload?.Invoke();
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
