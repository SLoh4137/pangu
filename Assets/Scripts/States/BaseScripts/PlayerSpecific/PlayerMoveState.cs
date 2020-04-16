using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/PlayerMove")]
    public class PlayerMoveState : StateData
    {
        public float acceleration = 1.0f;
        public float deceleration = 1.0f;

        private Vector2 velocity;
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // If moveHorizontal is non-zero, then accelerate towards it
            // If moveHorizontal is zero, then start decelerating
            float accel = characterControl.MoveHorizontal != 0 ? acceleration : deceleration;
            velocity.x = Mathf.MoveTowards(velocity.x, characterControl.MoveSpeed * characterControl.MoveHorizontal, accel * Time.deltaTime);

            if (velocity.x == 0)
            {
                animator.SetBool(Transition.isIdle.ToString(), true);
            }

            characterControl.transform.Translate(velocity * Time.deltaTime);
            characterControl.CollisionDetection();
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(Transition.isWalk.ToString(), false);
        }
    }
}

