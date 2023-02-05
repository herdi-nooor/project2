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
        private float timer;
        private void Start()
        {
        }
        
        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Spawn();
                timer = 2f;
            }
        }

        private void Spawn()
        {
            var j = Random.Range(1, EnemySpawner.SharedInstance.GetTotalObjectPolled());
            enemy = EnemySpawner.SharedInstance.GetPooledObject("Enemy", j);
            Spawnpointcurrent = Random.Range(0, 7);
            if (enemy != null && !enemy.activeInHierarchy)
            {
                if (Spawnpointcurrent != i)
                {
                    enemy.transform.position = spawnPoin[Spawnpointcurrent].transform.position;
                    enemy.transform.rotation = spawnPoin[Spawnpointcurrent].transform.rotation;
                    enemy.SetActive(true);
                    i = Spawnpointcurrent;
                }
            }
        }
    }
}