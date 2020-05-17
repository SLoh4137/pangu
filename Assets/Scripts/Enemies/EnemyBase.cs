using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class EnemyBase : MonoBehaviour, ICharacter
    {
        public CharacterStats Stats { get; set; }

        public GameObject Hurtbox;
        public GameObject Hitbox;

        private Flock flock;
        public Flock Flock
        {
            get
            {
                if (flock == null)
                {
                    flock = GetComponentInChildren<Flock>();
                }
                return flock;
            }
        }
        private Rigidbody2D rb;
        public Rigidbody2D Rigidbody
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody2D>();
                }
                return rb;
            }
        }

        public abstract void TakeDamage(int damage);

        public abstract void DealDamage(ICharacter character);

        public void DestroyEnemy()
        {
            //Flock.DestroyFlock();
            Destroy(gameObject);
        }
    }
}

