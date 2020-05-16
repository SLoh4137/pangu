using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pangu
{
    public interface ICanConsume
    {
        CharacterStats Stats { get; }
        Transform transform { get; }
        event Action<ICharacter> onAttack;
        event Action<ICharacter> onDefend;

        void Consume(ItemName item);
    }
}