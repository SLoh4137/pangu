using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerIdleState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.MoveWalk();
            // if(Control.MoveHorizontal != 0)
            // {
            //     animator.SetBool(PlayerTransition.isWalk.ToString(), true);
            //     animator.SetBool(PlayerTransition.isIdle.ToString(), false);
            // }

            if (Control.Jump && Control.DetectGround())
            {
                animator.SetTrigger(PlayerTransition.Jump.ToString());
            }
            else if (Control.Crouch)
            {
                animator.SetBool(PlayerTransition.isCrouch.ToString(), true);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {
            
        }
    }
}

