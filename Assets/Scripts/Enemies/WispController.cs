using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(CharacterStats))]
    public class WispController : EnemyBase
    {

        private Animator animator;

        private Rigidbody2D rb;
        public new Rigidbody2D Rigidbody { get { return rb; } }


        #region lifecycle
        void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            Stats = GetComponent<CharacterStats>();
        }

        #endregion lifecycle

        public override void TakeDamage(int damage)
        {
            Stats.Health -= damage;
            animator.SetTrigger(EnemyTransition.Hurt.ToString());
            Debug.Log(gameObject.name + " was damaged");
            if(Stats.Health <= 0)
            {
                Death();
            }
        }

        public override void DealDamage(ICharacter character)
        {

        }

        public void Death()
        {
            animator.SetBool(EnemyTransition.isDead.ToString(), true);
            Debug.Log(gameObject.name + " died");
        }
    }
}

