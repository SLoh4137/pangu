using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public interface ICharacter
    {
        CharacterStats Stats { get; set; }

        void TakeDamage(int damage);
        void DealDamage(ICharacter character);
    }
}

