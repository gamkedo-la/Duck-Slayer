using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceResize : MonoBehaviour
{
    private float ratio = 0.3f;

    public void Scale(float distance)
    {
        this.transform.localScale = Vector3.one*ratio*distance;
    }
}
