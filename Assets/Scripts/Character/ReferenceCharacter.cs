using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class ReferenceCharacter : MonoBehaviour
    {
        private ICharacter character;
        public ICharacter Character
        {
            get
            {
                if(character == null)
                {
                    character = GetComponentInParent<ICharacter>();
                }
                return character;
            }
        }
    }
}

