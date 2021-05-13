using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Audio
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager instance = null;
        [SerializeField] private ObjectPool poolType;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            
            instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            if (poolType == null)
            {
                Debug.LogWarning("No pooltype set", gameObject);
                return;
            }
            
            poolType.CreatePool(transform);
        }

        public ObjectPool GetPool() => poolType;
    }
}