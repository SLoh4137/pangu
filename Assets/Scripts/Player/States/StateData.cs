using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class StateData : ScriptableObject
    {
        public float Duration;
    
        public abstract void OnEnter(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void Update(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
    }
}

