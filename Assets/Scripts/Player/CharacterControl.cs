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

        public List<GameObject> GroundDetectionSpheres;

        public Vector3 Movement { get; set; } // so it can't be set in the Unity editor
        
    }
}

