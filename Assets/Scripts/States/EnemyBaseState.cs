using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class EnemyBaseState : StateMachineBehaviour
    {
        private EnemyBase control;
        public EnemyBase Control {
            get {
                return control; 
            } 
        }

        public void GetControl(Animator animator) {
            if(control == null) 
            {
                control = animator.GetComponent<EnemyBase>();
            }
        }

        public abstract override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    }
}

