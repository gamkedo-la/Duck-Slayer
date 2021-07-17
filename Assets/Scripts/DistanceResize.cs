using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceResize : MonoBehaviour
{
    [SerializeField] float ratio = 0.3f;

    public void Scale(float distance)
    {
        transform.localScale = Vector3.one * ratio * distance;
    }
}
