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
                Debug.Log(destination);
                nextMoveTime = Time.time + IdleTime;
                Debug.Log(Time.time);
                Debug.Log(nextMoveTime);
            }

            Control.transform.position = Vector2.MoveTowards(Control.transform.position, destination, Control.Speed * Time.deltaTime);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
        {
            
        }
    }
}

