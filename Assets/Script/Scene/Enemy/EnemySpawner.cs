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
            if ((!pObject.activeInHierarchy)
                && (pObject.name.Split(' ')[1] == i.ToString())
                && (pObject.CompareTag(tag)))
            {
                Debug.Log($"{pObject.name}\nindex obj {i}");
                return pObject;
            }
            return null;
        }

        ///////
    /// di inspector ubah
    // > item To Pool
    //      size                [             ]
    //      v Element 0
    //          Object To Pool  [ playerBullet]
    //          Amount To Pool  [ 20          ]
    //          Should Expand   [V]
    // > PooledObject
    /// menjadi seperti ini
    // > item To Pool
    //      size                [             ]
    //      v Element 0
    //          Object To Pool  [ playerBullet]
    //          Amount To Pool  [ 20          ]
    //          Should Expand   [V]
    //      v Element 0
    //          Object To Pool  [ enemyDrone1 ]
    //          Amount To Pool  [ 20          ]
    //          Should Expand   [V]
    //      v Element 0
    //          Object To Pool  [ enemyDrone2 ]
    //          Amount To Pool  [ 20          ]
    //          Should Expand   [V]
    // > PooledObject

    //// di script yang mengendalikan gelombang serangan(ext.Dronecontroller)
    //
    //GameObject enemy1 = ObjectPooler.SharedInstance.GetPooledObject("Enemy1");
    //if (enemy1 != null)
    //{
    //    enemy1.transform.position = spawnPosition;
    //    enemy1.transform.rotation = spawnRotetion;
    //    enemy1.SetActive(true);
    //}

    //// untuk men destroy nya di controller  
    //
    // gameObject.SetActive(false);

    }
}