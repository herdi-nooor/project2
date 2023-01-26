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
            StartCoroutine("Spawn");
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(3.0f);
            var j = Random.Range(1, EnemySpawner.SharedInstance.GetTotalObjectPolled());
            enemy = EnemySpawner.SharedInstance.GetPooledObject("Enemy", j);
            Spawnpointcurrent = Random.Range(0, 7);
            if (enemy != null && !enemy.activeInHierarchy)
            {
                if (Spawnpointcurrent != i)
                {
                    Spawnpointcurrent = i;
                    Debug.Log($"enemy : {enemy.name}\npoint spawn : {Spawnpointcurrent}/{i}," +
                              $" spawnt point object : {spawnPoin[Spawnpointcurrent]}\ntranform : {spawnPoin[Spawnpointcurrent].transform.position}");
                    enemy.transform.position = spawnPoin[Spawnpointcurrent].transform.position;
                    enemy.transform.rotation = spawnPoin[Spawnpointcurrent].transform.rotation;
                    enemy.SetActive(true);
                }
            }
        }

    }
}