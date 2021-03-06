﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerFallState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            animator.SetBool(PlayerTransition.isGrounded.ToString(), false);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            bool isGrounded = Control.DetectGround();
            //bool isWallSlide = Control.CheckWallSliding(isGrounded);

            animator.SetBool(PlayerTransition.isGrounded.ToString(), isGrounded);
            //animator.SetBool(PlayerTransition.isWallSliding.ToString(), isWallSlide);

            Control.MoveWalkAir();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {

        }
    }
}

