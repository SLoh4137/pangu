using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerFallState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(Control.DetectGround())
            {
                animator.SetBool(PlayerTransition.isGrounded.ToString(), true);
            }

            if(Control.MoveHorizontal != 0)
            {
                Rigidbody2D rb = Control.Rigidbody;
                rb.velocity = new Vector2(Control.AirSpeed * Control.MoveHorizontal, rb.velocity.y);
            }

            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {

        }
    }
}

