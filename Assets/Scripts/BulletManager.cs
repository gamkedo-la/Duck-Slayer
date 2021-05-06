using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public int maxBullets;
    public float reloadSeconds;
    public TextMeshPro bulletDisplay;
    [SerializeField] GameObject cartridge;

    private int currentBullets;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
        cartridge.SetActive(false);
    }

    public void DecreaseBullets()
    {
        currentBullets--;
        bulletDisplay.text = "" + currentBullets;

        if (currentBullets <= 0)
            ShowReloadCartridge();
    }

    public void ShowReloadCartridge()
    {
        cartridge.SetActive(true);
    }

    public int GetBulletAmount()
    {
        return currentBullets;
    }

    public IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadSeconds);
        Reload();
    }

    public void Reload()
    {
        currentBullets = maxBullets;
        bulletDisplay.text = "" + currentBullets;
    }
}
