using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject Fill;

    public SpriteRenderer FillSprite;

    public float lastValue;

    public void SetValue(float FillValue)
    {
        lastValue = FillValue;

        Fill.transform.localScale = new Vector3(FillValue, 1, 1);


        if (FillValue >= .5)
        {

            FillSprite.color = new Color((-2 * FillValue) +2, 1, 0);

        }
        else
        {            
            FillSprite.color = new Color(1, 2 * FillValue, 0);
        }
    }


}
