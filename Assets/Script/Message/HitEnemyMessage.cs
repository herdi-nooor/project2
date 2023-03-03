using UnityEngine;

namespace Script.Message
{
    public struct HitEnemyMessage
    {
        public int Damage { get; set; }
        public GameObject Enemy { get; set; }

        public HitEnemyMessage(int damage, GameObject enemy)
        {
            Damage = damage;
            Enemy = enemy;
        }
    }
}