using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/Gravity")]
    public class Gravity : StateData
    {
        public float gravity = 9.8f;
        public float gravityMultiplier = 2.5f;
        public float pullMultiplier = 2.5f;

        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            Vector3 moveVector = characterControl.Movement;
            // If we're grounded, no need to add gravity
            if (characterControl.IsGrounded)
            {
                moveVector.y = 0; 
            }
            else
            {
                if (moveVector.y < 0f)
                {
                    // Already falling, so let's add additional gravity multiplier
                    moveVector += Vector3.down * gravityMultiplier;
                }
                else if (moveVector.y > 0f && !characterControl.Jump)
                {
                    // Currently rising but no longer holding jump button
                    moveVector += Vector3.down * pullMultiplier;
                }
                moveVector += Vector3.down * gravity * Time.deltaTime;
            }
            
            characterControl.Movement = moveVector;
            animator.SetFloat(Transition.VelocityY.ToString(), characterControl.Movement.y);
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

