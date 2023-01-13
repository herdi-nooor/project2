using UnityEngine;

namespace LightFight.Global
{
    public interface IDamageable
    {
        [HideInInspector] public int CurrentHp { get; set; }
        public int MaxHp { get; }

        public void Damege(object data);
    }   
}