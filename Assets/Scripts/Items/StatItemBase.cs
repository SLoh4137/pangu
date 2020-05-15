using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class StatItemBase : ItemBase
    {
        protected StatModifier InitialStatModifier;
        protected StatModifier AdditionalStatModifier;
        public StatItemBase(ItemName itemName) : base(itemName, ItemType.StatModifying) { }
    }
}

