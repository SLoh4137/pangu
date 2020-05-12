using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
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
        }

        #endregion lifecycle

        public override void TakeDamage(int damage)
        {
            
        }

        public override void DealDamage(ICharacter character)
        {

        }
    }
}

