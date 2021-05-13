using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "DuckSlayer/Create Object Pool")]
    public class ObjectPool : ScriptableObject
    {
        [SerializeField] private GameObject poolableObject;
        [SerializeField] private int poolSize;
        [SerializeField] private int maxPoolSize;
        private List<GameObject> pool;
        private Transform parent;

        public void CreatePool(Transform transform)
        {
            parent = transform;
            pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                var newObject = Instantiate(poolableObject, parent);
                pool.Add(newObject);
            }
        }

        public GameObject GetObject()
        {
            if (pool.Count > 0)
            {
                var poolObject = pool[0];
                pool.RemoveAt(0);
                return poolObject;
            }

            return Instantiate(poolableObject, parent);
        }

        public void ReturnObject(GameObject objectToReturn)
        {
            if (pool.Count >= maxPoolSize)
            {
                Destroy(objectToReturn);
                return;
            }
            
            pool.Add((objectToReturn));
        }
    }
}