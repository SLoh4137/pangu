using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class WispDeathState : EnemyBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            Control.Flock.DestroyFlock();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.DestroyEnemy();
        }
    }
}

