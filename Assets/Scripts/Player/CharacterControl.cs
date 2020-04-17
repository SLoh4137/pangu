using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class CharacterControl : MonoBehaviour
    {
        public CharacterController controller;
        public float MoveSpeed;
        public int Health;
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;
        public bool IsGrounded;
        
    }
}

