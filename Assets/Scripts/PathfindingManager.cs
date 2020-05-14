using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class PathfindingManager : Singleton<PathfindingManager>
    {
        public Transform player;

        public bool WithinDistance(Transform enemy, float sensingRadius)
        {
            return Vector2.Distance(enemy.position, player.position) <= sensingRadius;
        }

        public Vector2 MoveTowardsPlayer(Transform enemy, float enemySpeed)
        {
            return Vector2.MoveTowards(enemy.position, player.position, enemySpeed * Time.deltaTime);
        }
    }
}

