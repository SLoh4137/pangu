using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class Stat
    {
        private float _value;
        private bool isDirty;

        public Stat(float value)
        {
            _value = value;
        }

        public float Value
        {
            get
            {
                if (isDirty)
                {
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        private float CalculateFinalValue()
        {
            return _value;
        }
    }
}

