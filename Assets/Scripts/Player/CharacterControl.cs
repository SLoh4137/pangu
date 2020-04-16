using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public enum Transition
    {

    }

    public class CharacterControl : MonoBehaviour
    {
        public float MoveSpeed;
        public int Health;
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;
    }
}

