using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/GroundDetection")]
    public class GroundDetection : StateData
    {
        public float DetectionDistance = .25f;

        private void DetectGround(CharacterControl characterControl, Animator animator) {
            bool result = false;
            foreach(GameObject sphere in characterControl.GroundDetectionSpheres) 
            {
                RaycastHit hit;
                Debug.DrawRay(sphere.transform.position, Vector3.down * DetectionDistance, Color.black);
                if (Physics.Raycast(sphere.transform.position, Vector3.down, out hit, DetectionDistance)) 
                { 
                    result = true;
                    break;
                }
            }
            characterControl.IsGrounded = result;
            characterControl.CurrentJump = result ? 0 : characterControl.CurrentJump; // resets if grounded
            animator.SetBool(Transition.isGrounded.ToString(), result);
        }
        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            DetectGround(characterControl, animator);
        }
        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            DetectGround(characterControl, animator);
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }
    }
}

