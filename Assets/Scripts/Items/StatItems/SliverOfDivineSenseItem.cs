using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{

    public class SliverOfDivineSenseItem : StatItemBase
    {
        public SliverOfDivineSenseItem() : base(ItemName.SliverOfDivineSense)
        {
            InitialStatModifier = new StatModifier(0.5f, StatModType.Flat);
            AdditionalStatModifier = new StatModifier(0.25f, StatModType.Flat);
        }

        public override void AddEffect(CharacterStats stats, int stackNumber)
        {
            if (stackNumber == 1)
            {
                stats.Defense.AddModifier(InitialStatModifier);
            }
            else
            {
                stats.Defense.AddModifier(AdditionalStatModifier);
            }
        }

        public override bool RemoveEffect(CharacterStats stats, int stackNumber)
        {
            if (stackNumber == 0)
            {
                return stats.Defense.RemoveModifer(InitialStatModifier);
            }
            else
            {
                return stats.Defense.RemoveModifer(AdditionalStatModifier);
            }
        }
    }
}
