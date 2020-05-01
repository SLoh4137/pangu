using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
    public class AlignmentBehavior : FilteredFlockBehavior
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // If no neighbors, maintain current alignment
            if (context.Count == 0)
                return agent.transform.up;

            // Add all alignments of neighbors and average
            Vector2 move = Vector2.zero;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            foreach (Transform neighbor in filteredContext)
            {
                move += (Vector2)neighbor.transform.up;
            }

            return move / context.Count; // average
        }
    }
}