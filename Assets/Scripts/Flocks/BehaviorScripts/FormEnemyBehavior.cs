using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Form Enemy")]
    public class FormEnemyBehavior : FilteredFlockBehavior
    {
        
        public EnemyBase flockPrefab;
        public int neighborAmount = 50;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // Not even enough transforms in the area to form an enemy
            // If agent already stolen, then don't continue
            if (context.Count < neighborAmount) // || flock.IsAgentStolen(agent))
            {
                return Vector2.zero;
            }

            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            if (filteredContext.Count >= neighborAmount)
            {
                EnemyBase enemyBase = Instantiate(flockPrefab, agent.transform.position, Quaternion.identity);
                Flock enemyFlock = enemyBase.Flock;
                // Try adding enemies in here. Other option is adding in the instantiation of the flock
                // Capture agents when formed?
                foreach (Transform neighbor in filteredContext)
                {
                    FlockAgent neighborAgent = neighbor.GetComponent<FlockAgent>();
                    if (neighborAgent != null)
                    {
                        enemyFlock.StealAgentFromFlock(neighborAgent, neighborAgent.AgentFlock);
                    }

                }

                enemyFlock.StealAgentFromFlock(agent, agent.AgentFlock);
            }


            return Vector2.zero;
        }
    }
}