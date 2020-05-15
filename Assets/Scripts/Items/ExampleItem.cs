using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class ExampleItem : ItemBase
    {
        public ExampleItem() : base(ItemName.ExampleItem, ItemType.OnHitAttack) { }

        public override void AddEffect(CharacterStats stats, int stackNumber)
        {

        }
        public override bool RemoveEffect(CharacterStats stats, int stackNumber)
        {
            return true;
        }
    }
}

