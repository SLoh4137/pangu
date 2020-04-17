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
            Vector3 velocity = characterControl.Movement;
            if(characterControl.IsGrounded && velocity.y < 0f)
            {
                velocity.y = 0f;
            }

            if(velocity.y < 0f)
            {
                velocity.y -= characterControl.GravityMultiplier;
            }
            else if (characterControl.Movement.y > 0f && !characterControl.Jump)
            {
                velocity.y -= characterControl.PullMultiplier;
            }

            velocity.y -= characterControl.Gravity * Time.deltaTime;
            characterControl.Movement = velocity;


            // // Grounded but falling, then cancel out gravity
            // if (characterControl.IsGrounded && characterControl.Movement.y < 0f)
            // {  
            //     characterControl.Movement = Vector3.right * characterControl.Movement.x; // cancel out the movement by eliminating y
            //     return;
            // }

            // Vector3 gravityVector = Vector3.zero;

            // // Already falling, so let's add additional gravity multiplier
            // if(characterControl.Movement.y < 0f)
            // { 
            //     gravityVector = Vector3.down * characterControl.GravityMultiplier;
            // }
            // else if (characterControl.Movement.y > 0f && !characterControl.Jump) {
            //     // Currently rising but no longer holding jump button
            //     gravityVector = Vector3.down * characterControl.PullMultiplier;
            // }

            // gravityVector += Vector3.down * characterControl.Gravity * Time.deltaTime;
            // characterControl.Movement += gravityVector;
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
