using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/GroundDetection")]
    public class GroundDetection : StateData
    {
        public float DetectionDistance = .25f;
        public LayerMask CollideLayer;

        private void DetectGround(CharacterControl characterControl, Animator animator) {
            bool result = false;
            foreach(GameObject sphere in characterControl.GroundDetectionSpheres) 
            {
                RaycastHit2D hit = Physics2D.Raycast(sphere.transform.position, Vector3.down, DetectionDistance, CollideLayer);
                Debug.DrawRay(sphere.transform.position, Vector3.down * DetectionDistance, Color.black);
                if (hit.collider != null)
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

