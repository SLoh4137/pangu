using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class DestroyAfterPlay : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
            Destroy(animator.gameObject);
        }
    }
}

