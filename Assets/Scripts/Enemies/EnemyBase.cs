using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class EnemyBase : MonoBehaviour, ICharacter
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public Flock Flock {get; }
        public Rigidbody2D Rigidbody { get; }

        public abstract void TakeDamage(int damage);

        public abstract void DealDamage(ICharacter character);
    }
}

