using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class EnemyBase : MonoBehaviour, ICharacter
    {
        public CharacterStats Stats {get; set; }

        protected Flock flock;
        public Flock Flock {
            get {
                if(flock == null)
                {
                    flock = GetComponentInChildren<Flock>();
                }
                return flock;
            } 
        }
        public Rigidbody2D Rigidbody { get; }

        public abstract void TakeDamage(int damage);

        public abstract void DealDamage(ICharacter character);

        public void DestroyEnemy()
        {
            Flock.DestroyFlock();
            Destroy(gameObject);
        }
    }
}

