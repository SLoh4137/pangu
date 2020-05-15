using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/**
* Followed https://forum.unity.com/threads/tutorial-character-stats-aka-attributes-system.504095/
*/

namespace pangu
{
    [Serializable]
    public class Stat
    {
        public float BaseValue;
        protected float lastBaseValue = float.MinValue;

        protected float _value;
        protected bool isDirty = true;
        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public Stat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public Stat(float value) : this()
        {
            BaseValue = value;
        }

        public virtual float Value
        {
            get
            {
                if (isDirty || lastBaseValue != BaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;
            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];
                switch (mod.Type)
                {
                    case StatModType.Flat:
                        finalValue += mod.Value;
                        break;
                    case StatModType.PercentAdd:
                        sumPercentAdd += mod.Value; // Start by adding all modifiers of this type

                        // If we're at the end of the list or the next type isn't percent add
                        if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                        {
                            finalValue *= 1 + sumPercentAdd;
                            sumPercentAdd = 0;
                        }
                        break;
                    case StatModType.PercentMult:
                        finalValue *= 1 + mod.Value;
                        break;
                }
            }

            return (float)Math.Round(finalValue, 4);
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifierOrder);
        }

        public virtual bool RemoveModifer(StatModifier mod)
        {
            bool result = statModifiers.Remove(mod);
            isDirty = isDirty || result;
            return result;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            isDirty = isDirty || didRemove;
            return didRemove;
        }


        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            return a.Order - b.Order;
        }
    }


}

