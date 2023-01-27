using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Enemy
{
    public class EnemySpawner : MonoBehaviour
    
    {
        public static EnemySpawner SharedInstance;
        public List<ObjectPoolItem> ItemToPool;
        public List<GameObject> pooledObjects;

        private void Awake() {
            SharedInstance = this;
        }
        
        private void Start() {
            pooledObjects = new List<GameObject>();
            int j = 0;
            foreach (ObjectPoolItem item in ItemToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    j += 1;
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    obj.name = obj.name + " " +j.ToString();
                    pooledObjects.Add(obj);
                }
            }
        }

        public int GetTotalObjectPolled()
        {
            return pooledObjects.Count;
        }

        public GameObject GetPooledObject(string tag, int i)
        {
            var pObject = pooledObjects[i - 1];
            if ((!pObject.activeInHierarchy) && (pObject.name.Split(' ')[1] == i.ToString()) &&
                (pObject.CompareTag(tag))) return pObject;
            return null;
        }
    }
}