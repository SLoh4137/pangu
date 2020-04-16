using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/Idle")]
    public class IdleState : StateData
    {
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(characterControl.MoveHorizontal != 0) {
                animator.SetBool(Transition.isWalk.ToString(), true);
            }
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(Transition.isIdle.ToString(), false);
        }
    }
}
