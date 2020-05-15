using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class OnHitItemBase : ItemBase
    {
        public OnHitItemBase(ItemName itemName) : base(itemName, ItemType.OnHitAttack) { }
    }
}

