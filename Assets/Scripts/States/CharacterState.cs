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

            // if (characterControl.HasGravity)
            // {
            //     ApplyGravity();
            // }

            // characterControl.controller.Move(characterControl.Movement * Time.deltaTime);
            //animator.SetFloat(Transition.VelocityY.ToString(), characterControl.rb.velocity.y);
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
