﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerCrouchState : PlayerBaseState
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

            if (!Control.Crouch)
            {
                animator.SetBool(PlayerTransition.isCrouch.ToString(), false);
            }

            // Check if can jump
            if (Control.Jump && Control.DetectGround())
            {
                animator.SetTrigger(PlayerTransition.Jump.ToString());
                animator.SetBool(PlayerTransition.isCrouch.ToString(), false);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }
    }
}

