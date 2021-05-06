using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildren : MonoBehaviour
{
    [SerializeField] GameObject[] childrenToDetach;
    public float destroyTimer;

    public string functionToInvoke;

    //private void OnDestroy()
    //{
    //    DetachAndInvoke();
    //}

    public void DetachAndInvoke()
    {
        foreach (GameObject child in childrenToDetach)
        {
            child.transform.parent = null;
            child.BroadcastMessage(functionToInvoke);
            Destroy(child, destroyTimer);
        }
    }
}
