using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerWallSlideState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.MoveWallSlide();

            bool isWallSlide = Control.CheckWallSliding();

            animator.SetBool(PlayerTransition.isWallSliding.ToString(), isWallSlide);
            if(Control.Jump && isWallSlide)
            {
                animator.SetTrigger(PlayerTransition.Jump.ToString());
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {
            
        }
    }
}

