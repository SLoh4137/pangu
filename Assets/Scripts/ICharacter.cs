using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public interface ICharacter
    {
        #region publicvars
        int MaxHealth { get; set; }
        int Health { get; set; }
        // public int Defense;
        // public int Speed;
        // public int JumpForce;

        // public float AttackRate;
        // public float AttackRange;

        // [Range(0, 100)]
        // public float CritChance;
        // public int CritDamageMult;
        #endregion publicvars

        void TakeDamage(int damage);
        void DealDamage(ICharacter character);
    }
}

