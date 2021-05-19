using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Audio
{
    public class PoolManager : MonoBehaviour
    {
        //public static PoolManager instance = null;
        [SerializeField] private ObjectPool poolType;
        private void Awake()
        {
            if (poolType == null)
            {
                Debug.LogWarning("No pooltype set", gameObject);
                return;
            }
            
            poolType.CreatePool(transform);
        }
    }
}