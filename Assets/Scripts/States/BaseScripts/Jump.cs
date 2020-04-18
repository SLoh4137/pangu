using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu.states
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/Jump")]
    public class Jump : StateData
    {
        public float JumpForce = 10f;
        private float precomputeJumpHeight;
        
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!characterControl.Jump || characterControl.CurrentJump >= characterControl.MaxJumps) return; // Not jumping 

            Debug.Log("called");
            characterControl.CurrentJump++;
            characterControl.rb.velocity += Vector2.up * JumpForce;

            //Vector3 velocity = characterControl.Movement;
            // characterControl.Movement += Vector3.up * precomputeJumpHeight;
            
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

