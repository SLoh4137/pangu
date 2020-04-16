using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class CharacterControl : MonoBehaviour
    {
        public float MoveSpeed;
        public int Health;
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;

        public abstract void CollisionDetection();
    }
}

