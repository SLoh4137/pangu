﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class FlyingSwordItem : OnHitItemBase
    {
        private GameAssets assets;
        public FlyingSwordItem() : base(ItemName.FlyingSword)
        {
            assets = GameAssets.Instance;
        }

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
            DamagePopup.Create(character.transform.position, 5);
            assets.Create(assets.pfSwordAttack, character.transform.position, Quaternion.identity, character.transform);
        }
    }
}

