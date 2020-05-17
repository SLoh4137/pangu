using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class Director : Singleton<Director>
    {
        public Timer timer;
        public Transform Player;
        public LevelEnemyList EnemyList;
        public float ElapsedTime;

        [Range(0f, 1f)]
        public float ChanceToSpend;
        private int spawnPoints;
        private float nextSecond;
        private FlockManager flockManager;
        // Start is called before the first frame update
        void Start()
        {
            ElapsedTime = 0;
            nextSecond = Time.deltaTime + 1f;
            spawnPoints = 0;
            flockManager = FlockManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            ElapsedTime += Time.deltaTime;
            if (nextSecond <= ElapsedTime)
            {
                spawnPoints++;
                nextSecond = ElapsedTime + 1;
                timer.SetTime(ElapsedTime);

                // Maybe changing this to net time to spend would be more efficient than calculating a new random value every frame
                if (Random.Range(0f, 1f) <= ChanceToSpend)
                {
                    SpendPoints();
                }
            }
        }

        // Tries to maximize spending of points
        // Will eventually use minimum coin problem with dynamic programming
        // For now just spawns flock members and fully formed wisps
        void SpendPoints()
        {
            if (spawnPoints <= 0) return;

            Vector2 randomPos = PickRandomPointAroundPlayer();
            LevelEnemyList.EnemyAndCost enemy = EnemyList.enemies[0]; // bad code but good enough for now
            while (spawnPoints > 0)
            {
                if (spawnPoints > enemy.cost)
                {
                    Instantiate(enemy.enemyPrefab, randomPos, Quaternion.identity, transform);
                    spawnPoints -= enemy.cost;
                }
                else
                {
                    flockManager.UnclaimedFlock.SpawnMember(randomPos, Quaternion.identity);
                    spawnPoints -= 1;
                }

            }
        }

        // Picks random valid point
        Vector2 PickRandomPointAroundPlayer()
        {
            return (Vector2) Player.position + Random.insideUnitCircle * 10;
        }
    }
}

