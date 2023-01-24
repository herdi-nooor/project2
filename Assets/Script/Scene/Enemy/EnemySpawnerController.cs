using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LightFight.Enemy
{
    public class EnemySpawnerController : MonoBehaviour
    {
        public List<GameObject> spawnPoin;
        public GameObject enemy;
        private int Spawnpointcurrent, i;
        private void Start()
        {
        }
        
        private void Update()
        {
            //StartCoroutine("Spawn");
            for (int i = 0; i < 10000; i++)
            {
                if (i == 9999)
                {
                    Spawner();
                    
                    Debug.Log(i);
                }
                i = Random.Range(0, 5);
            }
        }

        // private IEnumerator Spawn()
        // {
        //     enemy = EnemySpawner.SharedInstance.GetPooledObject("Enemy");
        //     Debug.Log($"enemy : {enemy}\npoint spawn : {Spawnpointcurrent}");
        //     yield return new WaitForSeconds(5.0f);
        //     Spawner();
        // }

        private void Spawner()
        {
                Debug.Log(Spawnpointcurrent);
            if (enemy != null && Spawnpointcurrent != i)
            {
                Spawnpointcurrent = i;
                enemy.transform.position = spawnPoin[Spawnpointcurrent].transform.position;
                enemy.transform.rotation = spawnPoin[Spawnpointcurrent].transform.rotation;
                enemy.SetActive(true);
            }
        }
    }
}