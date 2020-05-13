using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Stats/BaseStats")]
    public class StartingStats : ScriptableObject
    {
        [Header("Character")]
        public int StartingHealth;

        public int Defense;
        public int Speed;
        public int AirSpeed;
        public int JumpForce;

        [Header("Attack")]
        public float AttackRate;
        public float AttackRange;
        public int AttackDamage;
        public int Knockback;

        [Range(0, 100)]
        public float CritChance;
        public int CritDamageMultiplier;

        [Header("Sensing")]
        public float SensingRadius;
    }
}
