﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class WispHurtState : EnemyBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetControl(animator);
            Control.Hurtbox.SetActive(false);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Control.Hurtbox.SetActive(true);
        }
    }
}

