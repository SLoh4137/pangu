using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class FlyingSwordItem : OnHitItemBase
    {
        public FlyingSwordItem() : base(ItemName.FlyingSword) { }

        public override void AddEffect(ICanConsume character, int stackNumber)
        {
            character.onAttack += AdditionalAttack;
        }

        public override bool RemoveEffect(ICanConsume character, int stackNumber)
        {
            character.onAttack -= AdditionalAttack;
            return true;
        }

        public void AdditionalAttack(ICharacter character)
        {
            character.TakeDamage(5);
        }
    }
}

