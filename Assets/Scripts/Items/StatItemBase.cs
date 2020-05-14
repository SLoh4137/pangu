using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public abstract class StatItemBase : ItemBase
    {
        public Stat stat;
        public StatItemBase(string name) : base(name, ItemType.StatModifying) { }
    }
}

