using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "DuckSlayer/Create Object Pool")]
    public class ObjectPool : ScriptableObject
    {
        [SerializeField] private GameObject poolableObject;
        [SerializeField] private int poolSize;
        [SerializeField] private int maxPoolSize;
        private Queue<GameObject> pool = new Queue<GameObject>();
        private Transform parent;

        public void CreatePool(Transform transform)
        {
            //pool.Clear();
            parent = transform;
            pool = new Queue<GameObject>();

            while (pool.Count < poolSize)
            {
                var newObject = Instantiate(poolableObject, parent);
                pool.Enqueue(newObject);
            }
        }

        public GameObject GetObject()
        {
            if (pool != null && pool.Count > 0)
            {
                var poolObject = pool.Dequeue();
                //pool.Enqueue(poolObject);
                ReturnObject(poolObject);
                return poolObject;
            }

            var newObject = Instantiate(poolableObject, parent);

            if (pool != null)
                ReturnObject(newObject);
            return newObject;
        }

        public void ReturnObject(GameObject objectToReturn)
        {
            pool.Enqueue(objectToReturn);

            //Debug.Log("Returning Object: " + objectToReturn.name + " Pool Count: " + pool.Count);

            if (pool.Count < maxPoolSize)
                return;

            Cleanup();
        }

        private void Cleanup()
        {
            while (pool.Count > maxPoolSize)
            {
                var excessObject = pool.Dequeue();
                Destroy(excessObject);
                Debug.LogWarning(("destroyed excess object"));
            }
        }
    }
}