using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu.states
{
    
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/Jump")]
    public class Jump : StateData
    {
        public Vector2 JumpForceVector;
        public float JumpTimeLength;
        private float elapsedTime;
        private float nextTime;
        
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        { 
            // if(characterControl.Jump && characterControl.CurrentJump < characterControl.MaxJumps) {
            //     elapsedTime = 0;
            //     characterControl.CurrentJump++;
            // }

            // while(elapsedTime < JumpTimeLength) {
            //     float proportionCompleted = elapsedTime / JumpTimeLength;
            //     Vector2 curForceVector = Vector2.Lerp(JumpForceVector, Vector2.zero, proportionCompleted);
            //     characterControl.rb.AddForce(curForceVector);
            //     elapsedTime += Time.deltaTime;
            // }


            if(!characterControl.Jump || characterControl.CurrentJump >= characterControl.MaxJumps) return; // Not jumping 

            characterControl.CurrentJump++;
            // characterControl.rb.AddForce(JumpForceVector);
            characterControl.rb.velocity = new Vector2(characterControl.rb.velocity.x, 0) + JumpForceVector;

            // Vector3 velocity = characterControl.Movement;
            // characterControl.Movement += Vector3.up * precomputeJumpHeight;
            
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

