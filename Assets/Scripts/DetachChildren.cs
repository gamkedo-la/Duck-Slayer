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
        BroadcastMessage(functionToInvoke);
        foreach (GameObject child in childrenToDetach)
        {
            child.transform.parent = null;
            Destroy(child, destroyTimer);
        }
    }
}
