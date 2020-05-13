using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(PlayerControl))]
    public class PlayerCombat : MonoBehaviour
    {

        public PlayerControl control;
        public Transform attackPoint;
        public LayerMask enemyLayers;

        private float nextAttackTime;

        // Start is called before the first frame update
        void Awake()
        {
            control = GetComponent<PlayerControl>();
            nextAttackTime = Time.time;
        }

        void Update()
        {
            // Can't attack yet
            if (nextAttackTime >= Time.time || !control.Attacking)
            {
                return;
            }

            nextAttackTime = Time.time + 1f / control.Stats.AttackRate.Value;
            OnAttack();
        }

        public void OnAttack()
        {
            control.Animator.SetTrigger(PlayerTransition.Attack.ToString());
            
            // Detect enemies within range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, control.Stats.AttackRange.Value, enemyLayers);

            // Damage enemies
            foreach (Collider2D enemy in hitEnemies)
            {  
                control.DealDamage(enemy.GetComponent<ReferenceControl>().Control);
            }
        }

        void OnDrawGizmos()
        {
            if (attackPoint == null || control.Stats == null) return;

            Gizmos.DrawWireSphere(attackPoint.position, control.Stats.AttackRange.Value);
        }
    }
}

