using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Audio
{
    public class PoolSpawner : MonoBehaviour
    {
        //public static PoolManager instance = null;
        [SerializeField] private ObjectPool poolType;
        [SerializeField] private int poolCount;

        private void Awake()
        {
            if (poolType == null)
            {
                Debug.LogWarning("No pooltype set", gameObject);
                return;
            }

            poolType.CreatePool(transform);
        }

        private void Update()
        {
            var children = GetComponentsInChildren<Transform>();
            poolCount = children.Length;
        }
    }
}