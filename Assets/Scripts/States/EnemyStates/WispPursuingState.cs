using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pangu
{
    public class WispPursuingState : EnemyBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.transform.position = PathfindingManager.Instance.MoveTowardsPlayer(Control.transform, Control.Stats.Speed.Value);
            if (!PathfindingManager.Instance.WithinDistance(Control.transform, Control.Stats.SensingRadius.Value))
            {
                animator.SetBool(EnemyTransition.isPlayerSensed.ToString(), false);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}