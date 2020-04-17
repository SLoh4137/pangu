using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public enum Transition
    {
        isIdle,
        isWalk,
        isGrounded,
        isJumping,
        VelocityY,
    }
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> ListAbilityData = new List<StateData>();
        private CharacterControl characterControl;
        public CharacterControl GetCharacterControl(Animator animator)
        {
            if (characterControl == null)
            {
                characterControl = animator.GetComponentInParent<CharacterControl>();
            }
            return characterControl;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetCharacterControl(animator);
            foreach (StateData state in ListAbilityData)
            {
                state.OnEnter(characterControl, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetCharacterControl(animator);

            foreach (StateData state in ListAbilityData)
            {
                state.UpdateAbility(characterControl, animator, stateInfo);
            }

            if (characterControl.HasGravity)
            {
                ApplyGravity();
            }

            characterControl.controller.Move(characterControl.Movement * Time.deltaTime);
            animator.SetFloat(Transition.VelocityY.ToString(), characterControl.Movement.y);
        }

        public void ApplyGravity()
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
                    moveVector += Vector3.down * characterControl.GravityMultiplier;
                }
                else if (moveVector.y > 0f && !characterControl.Jump)
                {
                    // Currently rising but no longer holding jump button
                    moveVector += Vector3.down * characterControl.PullMultiplier;
                }
                moveVector += Vector3.down * characterControl.Gravity * Time.deltaTime;
            }

            characterControl.Movement = moveVector;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetCharacterControl(animator);
            foreach (StateData state in ListAbilityData)
            {
                state.OnExit(characterControl, animator, stateInfo);
            }
        }

    }

}
