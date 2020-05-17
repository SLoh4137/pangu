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

            if (Control.MoveHorizontal == 0)
            {
                animator.SetBool(PlayerTransition.isIdle.ToString(), true);
            }

            Control.MoveWalkAir();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {

        }
    }
}

