using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "EnemyList/EnemyList")]
    public class LevelEnemyList : ScriptableObject
    {
        public EnemyAndCost[] enemies;

        [System.Serializable]
        public struct EnemyAndCost
        {
            public EnemyBase enemyPrefab;
            public int cost;
        }
    }
}

