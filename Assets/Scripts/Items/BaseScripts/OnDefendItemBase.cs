using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class OnDefendItemBase : ItemBase
    {
        public OnDefendItemBase(ItemName itemName) : base(itemName, ItemType.OnDefend) { }
    }
}

