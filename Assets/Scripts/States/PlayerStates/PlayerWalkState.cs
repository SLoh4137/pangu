﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerWalkState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // If moveHorizontal is non-zero, then accelerate towards it
            // If moveHorizontal is zero, then start decelerating
            Control.MoveWalk();

            //rb.velocity = Vector2.right *  Mathf.MoveTowards(rb.velocity.x, MoveSpeed * characterControl.MoveHorizontal, acceleration * Time.deltaTime);
            //rb.velocity = Vector2.Lerp(rb.velocity, )

            // if (Control.MoveHorizontal == 0)
            // {
            //     animator.SetBool(PlayerTransition.isIdle.ToString(), true);
            //     animator.SetBool(PlayerTransition.isWalk.ToString(), false);
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

