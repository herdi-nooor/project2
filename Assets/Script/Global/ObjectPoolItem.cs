using UnityEngine;

namespace LightFight.Enemy
{   
    [System.SerializableAttribute]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
    }
}

