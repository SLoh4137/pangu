using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Steal")]
    public class StealBehavior : FilteredFlockBehavior
    {

        [Range(0, 1)]
        public float stealChance = 0.5f;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // If no neighbors, nothing to steal
            if (context.Count == 0)
                return Vector2.zero;

            // Instead of moving, steal!
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            foreach (Transform neighbor in filteredContext)
            {
                FlockAgent neighborAgent = neighbor.GetComponent<FlockAgent>();
                if (neighborAgent != null && Random.Range(0f, 1f) < stealChance)
                {
                    flock.StealAgentFromFlock(neighborAgent, neighborAgent.AgentFlock);
                }

            }

            return Vector2.zero; // nothing to move
        }
    }
}