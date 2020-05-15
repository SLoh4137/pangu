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
        public ItemName itemName;
        public ItemType type;

        public ItemBase(ItemName _itemName, ItemType _type)
        {
            // name = _itemName.ToString();
            itemName = _itemName;
            type = _type;
        }

        public abstract void AddEffect(ICanConsume character, int stackNumber);
        public abstract bool RemoveEffect(ICanConsume character, int stackNumber);

        // override object.Equals
        public override bool Equals(object obj)
        {       
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return itemName == ((ItemBase) obj).itemName;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int) itemName;
        }
    }
}

