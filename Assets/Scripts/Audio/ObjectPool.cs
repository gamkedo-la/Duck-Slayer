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
        private Queue<GameObject> pool;
        private Transform parent;

        public void CreatePool(Transform transform)
        {
            //pool.Clear();
            parent = transform;
            pool = new Queue<GameObject>(poolSize);

           while(pool.Count < poolSize)
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

            return Instantiate(poolableObject, parent);
        }

        public void ReturnObject(GameObject objectToReturn)
        {
            pool.Enqueue(objectToReturn);
            
            Debug.Log("Returning Object: " + objectToReturn.name + " Pool Count: " + pool.Count);
            
            if (pool.Count >= maxPoolSize)
            {
                pool.TrimExcess();
                Debug.Log("Trimming Excess from Queue");
            }
        }
    }
}