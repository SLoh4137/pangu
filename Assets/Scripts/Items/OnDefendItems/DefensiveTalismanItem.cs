﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class DefensiveTalismanItem : StatItemBase
    {
        private GameAssets assets;
        public DefensiveTalismanItem() : base(ItemName.FlyingSword)
        {
            assets = GameAssets.Instance;
            InitialStatModifier = new StatModifier(1f, StatModType.Flat);
            AdditionalStatModifier = new StatModifier(0.5f, StatModType.Flat);
        }

        public override void AddEffect(ICanConsume character, int stackNumber)
        {     
            if (stackNumber == 1)
            {
                character.onDefend += OnDefend;
                character.Stats.Defense.AddModifier(InitialStatModifier);
            }
            else
            {
                character.Stats.Defense.AddModifier(AdditionalStatModifier);
            }
        }

        public override bool RemoveEffect(ICanConsume character, int stackNumber)
        {
            if(stackNumber == 0)
            {
                character.onAttack -= OnDefend;
                character.Stats.Defense.RemoveModifer(InitialStatModifier);
            }
            else 
            {
                character.Stats.Defense.RemoveModifer(AdditionalStatModifier);
            }
            
            return true;
        }

        public void OnDefend(ICharacter character)
        {
            assets.Create(assets.pfDefend, character.transform.position, Quaternion.identity, character.transform);
        }
    }
}
