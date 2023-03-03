using Script.Scene.GamePlay.Enemy.Enemy_Type;
using UnityEngine;

namespace Script.Scene.GamePlay.Enemy
{
    [CreateAssetMenu(fileName = "Enemydata", menuName = "Enemy/Data", order = 0)]
    public class BaseDataEnemy : ScriptableObject
    {
        public float MoveSpeed;
        public bool FacingRight = false;
        public TypeEnemy TypeEnemy;
        public int MaxHp = 0;
    }
}
