using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public enum ItemType
    {
        StatModifying,
        OnHitAttack,
    }
    public abstract class ItemBase
    {
        public int StackCount = 0;
        public string name;
        public ItemType type;

        public ItemBase(string _name, ItemType _type)
        {
            name = _name;
            type = _type;
        }

        public abstract void Attach(ICanConsume character);
        public abstract void Remove(ICanConsume character);
    }
}

