using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pangu
{
    public interface ICanConsume
    {
        CharacterStats Stats { get; }
        event Action onAttack;
        event Action onDefend;
    }
}