using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Global
{
    [CreateAssetMenu(fileName = "Characterdata", menuName = "Character/Data", order = 0)]
    public class DataCharacter : ScriptableObject
    {
        public float Speed;
        public float JumpForce;
        public float Healt;
        public string weapon;
    }
}
