using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class JumpState : StateData
    {
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(Transition.isJumping.ToString(), false);
        }
    }
}

