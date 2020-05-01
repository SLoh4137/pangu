using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName= "Flock/Behavior/Steered Cohesion")]
    public class SteeredCohesionBehavior : FilteredFlockBehavior
    {
        private Vector2 currentVelocity;
        public float agentSmoothTime = 0.5f;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // If no neighbors, then nothing to move towards
            if (context.Count == 0)
                return Vector2.zero;

            // Add all points together and average
            Vector2 move = Vector2.zero;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

            foreach (Transform item in filteredContext)
            {
                move += (Vector2)item.position;
            }

            move /= context.Count;

            // Create offset from agent's current position
            move -= (Vector2) agent.transform.position;
            move = Vector2.SmoothDamp(agent.transform.up, move, ref currentVelocity, agentSmoothTime);
            return move;
        }
    }
}