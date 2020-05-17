using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(CharacterStats))]
    public class WispController : EnemyBase
    {

        private Animator animator;

        #region lifecycle
        void Awake()
        {
            animator = GetComponent<Animator>();
            Stats = GetComponent<CharacterStats>();
        }

        #endregion lifecycle

        public override void TakeDamage(int damage)
        {
            Stats.Health -= damage;
            animator.SetTrigger(EnemyTransition.Hurt.ToString());
            Debug.Log(gameObject.name + " was damaged for " + damage);
            if(Stats.Health <= 0)
            {
                Death();
            }
        }

        public override void DealDamage(ICharacter character)
        {
            float baseDamage = Stats.BaseDamage.Value;
            float range = Stats.DamageRange.Value;
            int damage = (int) Random.Range(baseDamage - range, baseDamage + range);

            character.TakeDamage((int) Stats.BaseDamage.Value);
        }

        public void Death()
        {
            animator.SetBool(EnemyTransition.isDead.ToString(), true);
            Debug.Log(gameObject.name + " died");
        }
    }
}

