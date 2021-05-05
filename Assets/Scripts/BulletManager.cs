using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public int maxBullets;
    public float reloadSeconds;
    public TextMeshPro bulletDisplay;

    private int currentBullets;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
    }

    public void DecreaseBullets()
	{
        currentBullets--;
        bulletDisplay.text = "" + currentBullets;
    }

    public int GetBulletAmount()
	{
        return currentBullets;
    }

    public IEnumerator Reload()
	{
        yield return new WaitForSeconds(reloadSeconds);
        currentBullets = maxBullets;
        bulletDisplay.text = "" + currentBullets;
    }
}
