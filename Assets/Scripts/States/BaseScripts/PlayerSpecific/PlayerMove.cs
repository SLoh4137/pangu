using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu.states
{
    [CreateAssetMenu(fileName = "New State", menuName = "Pangu/Ability/PlayerMove")]
    public class PlayerMove : StateData
    {
        public float MoveSpeed = 10.0f;

        public override void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // Unused
        }

        public override void UpdateAbility(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            // If moveHorizontal is non-zero, then accelerate towards it
            // If moveHorizontal is zero, then start decelerating
            Rigidbody2D rb = characterControl.rb;
            rb.velocity = new Vector2(MoveSpeed * characterControl.MoveHorizontal, rb.velocity.y);
            //rb.velocity = Vector2.right *  Mathf.MoveTowards(rb.velocity.x, MoveSpeed * characterControl.MoveHorizontal, acceleration * Time.deltaTime);

            //rb.velocity = Vector2.Lerp(rb.velocity, )

            if (characterControl.MoveHorizontal == 0)
            {
                animator.SetBool(Transition.isIdle.ToString(), true);
            }
            else if (characterControl.MoveHorizontal < 0 && characterControl.FacingRight)
            {
                characterControl.Flip();
            }
            else if (characterControl.MoveHorizontal > 0 && !characterControl.FacingRight)
            {
                characterControl.Flip();
            }




            // characterControl.Movement = velocity; // Note that movement is currently being handled in CharacterState
            //characterControl.transform.forward = velocity;
        }
        public override void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(Transition.isWalk.ToString(), false);
        }
    }
}

