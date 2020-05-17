using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{

    public class SliverOfDivineSenseItem : StatItemBase
    {
        public SliverOfDivineSenseItem() : base(ItemName.SliverOfDivineSense)
        {
            InitialStatModifier = new StatModifier(1f, StatModType.Flat);
            AdditionalStatModifier = new StatModifier(0.5f, StatModType.Flat);
        }

        public override string NameText { get { return "Sliver of Divine Sense"; }}
        public override string Description { get { return "Increases the user's attack range"; }}


        public override void Add(ICanConsume character, int stackNumber)
        {
            if (stackNumber == 1)
            {
                character.Stats.AttackRange.AddModifier(InitialStatModifier);
            }
            else
            {
                character.Stats.AttackRange.AddModifier(AdditionalStatModifier);
            }
        }

        public override bool Remove(ICanConsume character, int stackNumber)
        {
            if (stackNumber == 0)
            {
                return character.Stats.AttackRange.RemoveModifer(InitialStatModifier);
            }
            else
            {
                return character.Stats.AttackRange.RemoveModifer(AdditionalStatModifier);
            }
        }
    }
}
