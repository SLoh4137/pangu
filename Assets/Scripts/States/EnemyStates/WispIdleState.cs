using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class WispIdleState : EnemyBaseState
    {
        public float IdleTime = 1;
        private float nextMoveTime;
        private float nextCheckTime;
        private Vector2 destination;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            nextMoveTime = Time.time;
            nextCheckTime = Time.time;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (nextMoveTime < Time.time)
            {
                destination = (Vector2)Control.transform.position + Random.insideUnitCircle * 5;
                nextMoveTime = Time.time + IdleTime;
            }
            //Control.Rigidbody.MovePosition(Vector2.MoveTowards(Control.transform.position, destination, Control.Stats.Speed.Value * Time.deltaTime));
            Vector2 moveVector = Vector2.MoveTowards(Control.transform.position, destination, Control.Stats.Speed.Value * Time.deltaTime);
            Control.transform.position = moveVector;

            if (nextCheckTime <= Time.time)
            {
                if (PathfindingManager.Instance.WithinDistance(Control.transform, Control.Stats.SensingRadius.Value))
                {
                    animator.SetBool(EnemyTransition.isPlayerSensed.ToString(), true);
                }
                nextCheckTime = Time.time + .5f;
            }


        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}

