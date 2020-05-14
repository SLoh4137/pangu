using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PlayerAttackState : PlayerBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            Control.Hurtbox.gameObject.SetActive(true);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // if(Control.MoveHorizontal != 0)
            // {
            //     animator.SetBool(PlayerTransition.isWalk.ToString(), true);
            // }

            if(Control.Jump && Control.DetectGround())
            {
                animator.SetTrigger(PlayerTransition.Jump.ToString());
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {
            Control.Hurtbox.gameObject.SetActive(false);
        }
    }
}

