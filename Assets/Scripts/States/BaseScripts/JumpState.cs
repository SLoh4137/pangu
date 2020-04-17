﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/BaseJump")]
    public class BaseJumpState : StateData
    {
        public float JumpHeight = 10f;
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!characterControl.Jump || characterControl.CurrentJump >= characterControl.MaxJumps) return; // Not jumping 


            characterControl.CurrentJump++;
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}

