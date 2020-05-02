using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName= "Flock/Behavior/Stay with Flock")]
    public class StayWithFlockBehavior : FlockBehavior
    {
        public float radius = 15f;
        public float pullRadius = 0.9f;
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 centerOffset = (Vector2) (flock.transform.position - agent.transform.position);
            float t = centerOffset.magnitude / radius;

            // If the agent is within the pull radius, then don't need to influence
            if (t < pullRadius) {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }
    }
}