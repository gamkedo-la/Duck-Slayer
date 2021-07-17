using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceResize : MonoBehaviour
{
    [SerializeField] float ratio = 0.3f;
    [SerializeField] float maxDistance = 100;

    public void Scale(float distance)
    {
        var textSize = distance > maxDistance ? maxDistance : distance;
        transform.localScale = Vector3.one * ratio * textSize;
    }
}
