using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{
    [SerializeField] TransformRef PlayerPosition;

    void Awake()
    {
        PlayerPosition.value = transform;
    }

}
