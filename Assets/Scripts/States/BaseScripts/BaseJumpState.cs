using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/BaseJump")]
    public class BaseJumpState : StateData
    {
        public float JumpHeight = 10f;
        private float precomputeJumpHeight;
        
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            precomputeJumpHeight = Mathf.Sqrt(2 * JumpHeight * Mathf.Abs(characterControl.Gravity));
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!characterControl.Jump || characterControl.CurrentJump >= characterControl.MaxJumps) return; // Not jumping 

            //Vector3 velocity = characterControl.Movement;
            characterControl.Movement += Vector3.up * precomputeJumpHeight;
            characterControl.CurrentJump++;
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

