using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
    public class CompositeBehavior : FlockBehavior
    {
        [System.Serializable]
        public struct Behavior 
        {
            public FlockBehavior behavior;
            public float weight;
        }
        public Behavior[] behaviors;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 move = Vector2.zero;

            foreach (Behavior b in behaviors)
            {
                Vector2 partialMove = b.behavior.CalculateMove(agent, context, flock) * b.weight;

                if (partialMove != Vector2.zero)
                {
                    // If partial move is greater than our weight, then normalize it so it's exactly the weight
                    if (partialMove.sqrMagnitude > b.weight + b.weight)
                    {
                        partialMove.Normalize();
                        partialMove *= b.weight;
                    }

                    move += partialMove;
                }
            }

            return move;
        }
    }
}