using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Enemy
{
    [CreateAssetMenu(fileName = "Enemydata", menuName = "Enemy/Data", order = 0)]
    public class BaseDataEnemy : ScriptableObject
    {
        public float MoveSpeed;
        public bool FacingRight = false;
        public TypeEnemy TypeEnemy;
        public int MaxHp = 1;
    }

    public enum TypeEnemy
    {
        WALK, RUN, JUMP, FLY
    }
    
}
