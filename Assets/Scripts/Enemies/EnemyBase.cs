using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(Flock))]
    public abstract class EnemyBase : MonoBehaviour, ICharacter
    {
        public int SensingRadius;
        public int Speed;

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        protected Flock flock;
        public Flock Flock {
            get {
                if(flock == null)
                {
                    flock = GetComponent<Flock>();
                }
                return flock;
            } 
        }
        public Rigidbody2D Rigidbody { get; }

        public abstract void TakeDamage(int damage);

        public abstract void DealDamage(ICharacter character);
    }
}

