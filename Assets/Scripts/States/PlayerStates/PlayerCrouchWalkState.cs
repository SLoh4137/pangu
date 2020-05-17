using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerCrouchWalkState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.MoveCrouchWalk();

            // Check if can jump
            if (Control.Jump && Control.DetectGround())
            {
                animator.SetTrigger(PlayerTransition.Jump.ToString());
                animator.SetBool(PlayerTransition.isCrouch.ToString(), false);
            }

            if (!Control.Crouch)
            {
                animator.SetBool(PlayerTransition.isCrouch.ToString(), false);
            }

            // if (Control.MoveHorizontal == 0)
            // {
            //     animator.SetBool(PlayerTransition.isIdle.ToString(), true);
            //     animator.SetBool(PlayerTransition.isWalk.ToString(), false);
            // }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}

