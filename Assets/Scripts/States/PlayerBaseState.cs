using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public enum PlayerTransition
    {
        isIdle,
        isWalk,
        isGrounded,
        Jump,
        VelocityY,
    }
    public abstract class PlayerBaseState : StateMachineBehaviour
    {
        private PlayerControl control;
        public PlayerControl Control {
            get {
                return control; 
            } 
        }

        public void GetControl(Animator animator) {
            if(control == null) 
            {
                control = animator.GetComponentInParent<PlayerControl>();
            }
        }

        public abstract override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    }
}


