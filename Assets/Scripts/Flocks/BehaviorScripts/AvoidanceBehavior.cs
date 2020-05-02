using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
    public class AvoidanceBehavior : FilteredFlockBehavior
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // If no neighbors, nothing to avoid
            if (context.Count == 0)
                return Vector2.zero;

            // Add all points together and average
            Vector2 move = Vector2.zero;
            int nAvoid = 0;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

            foreach (Transform item in filteredContext)
            {
                Vector3 closestPoint = agent.ClosestPoint(item);
                if (Vector2.SqrMagnitude(closestPoint - agent.transform.position) < flock.SquareAvoidanceRadius)
                {
                    nAvoid++;
                    move += (Vector2)(agent.transform.position - closestPoint); // move in opposite direction
                }
            }

            return nAvoid > 0 ? move / nAvoid : move; // If there are items to avoid, then average
        }
    }
}