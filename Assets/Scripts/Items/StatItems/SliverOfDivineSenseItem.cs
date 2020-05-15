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

        public override void AddEffect(CharacterStats stats, int stackNumber)
        {
            if (stackNumber == 1)
            {
                stats.AttackRange.AddModifier(InitialStatModifier);
            }
            else
            {
                stats.AttackRange.AddModifier(AdditionalStatModifier);
            }
        }

        public override bool RemoveEffect(CharacterStats stats, int stackNumber)
        {
            if (stackNumber == 0)
            {
                return stats.AttackRange.RemoveModifer(InitialStatModifier);
            }
            else
            {
                return stats.AttackRange.RemoveModifer(AdditionalStatModifier);
            }
        }
    }
}
