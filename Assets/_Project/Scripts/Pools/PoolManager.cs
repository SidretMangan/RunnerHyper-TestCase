using System;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class PoolManager : MonoBehaviour
    {
        [Serializable]
        public struct Pool
        {
            public Queue<GameObject> pooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
        }

        [SerializeField] private Pool[] pools = null;
        private float zPosition = 15;
        private float xPosition;
        [SerializeField] private Transform objParent;

        private void Awake()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab,objParent);
                    obj.SetActive(false);
                    pools[j].pooledObjects.Enqueue(obj);
                }
            }
        }

        public GameObject GetPooledObject(int objectType)
        {
            if (objectType >= pools.Length)
            {
                return null;
            }

            GameObject obj = pools[objectType].pooledObjects.Dequeue();
            xPosition = UnityEngine.Random.Range(-2.2f, 2.2f);
            zPosition += 8;
            obj.transform.position = new Vector3(xPosition, 0.5f, zPosition);
            obj.SetActive(true);

            pools[objectType].pooledObjects.Enqueue(obj);

            return obj;
        }
    }
}
