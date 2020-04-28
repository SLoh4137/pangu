using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerJumpState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            control.RigidBody.AddForce(Vector2.up * control.JumpForce);
            animator.SetBool(PlayerTransition.isGrounded.ToString(), false);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {

        }
    }
}

