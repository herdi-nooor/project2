using UnityEngine;

namespace Script.Global
{   
    [System.SerializableAttribute]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
    }
}

