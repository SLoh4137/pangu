using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/PlayerMove")]
    public class PlayerMoveState : StateData
    {
        public float MoveSpeed = 10.0f;
        public float MoveAcceleration = 100.0f;
        public float MoveDeceleration = 100.0f;

        private Vector2 velocity;
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }

        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // If moveHorizontal is non-zero, then accelerate towards it
            // If moveHorizontal is zero, then start decelerating
            float acceleration = characterControl.MoveHorizontal != 0 ? MoveAcceleration : MoveDeceleration;
            velocity.x = Mathf.MoveTowards(velocity.x, MoveSpeed * characterControl.MoveHorizontal, acceleration * Time.deltaTime);

            if (velocity.x == 0)
            {
                animator.SetBool(Transition.isIdle.ToString(), true);
            }

            characterControl.controller.Move(velocity * Time.deltaTime);
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(Transition.isWalk.ToString(), false);
        }
    }
}

