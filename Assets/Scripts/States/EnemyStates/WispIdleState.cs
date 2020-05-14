using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class WispIdleState : EnemyBaseState
    {
        public float IdleTime = 1;
        private float nextMoveTime;
        private Vector2 destination;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            nextMoveTime = Time.time;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(nextMoveTime < Time.time) 
            {
                destination = (Vector2) Control.transform.position + Random.insideUnitCircle * 5;
                nextMoveTime = Time.time + IdleTime;
            }
            //Control.Rigidbody.MovePosition(Vector2.MoveTowards(Control.transform.position, destination, Control.Stats.Speed.Value * Time.deltaTime));
            Control.transform.position = Vector2.MoveTowards(Control.transform.position, destination, Control.Stats.Speed.Value * Time.deltaTime);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {
            
        }
    }
}

