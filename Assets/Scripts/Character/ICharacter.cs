using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public interface ICharacter
    {
        CharacterStats Stats { get; set; }
        Transform transform { get; }

        void TakeDamage(int damage);
        void DealDamage(ICharacter character);
    }
}

