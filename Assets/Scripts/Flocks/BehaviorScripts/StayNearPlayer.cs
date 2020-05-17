using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName= "Flock/Behavior/Stay near Player")]
    public class StayNearPlayerBehavior : FlockBehavior
    {
        private Transform player;
        public float radius = 10f;
        public float pullRadius = 0.9f;

        private Transform Player { 
            get {
                if(player == null)
                {
                    player = Director.Instance.Player;
                }
                return player;
            }
        }
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 centerOffset = (Vector2) (Player.transform.position - agent.transform.position);
            float t = centerOffset.magnitude / radius;

            // If the agent is within the pull radius, then don't need to influence
            if (t < pullRadius) {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }

    }
}