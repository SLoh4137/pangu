using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
    public class CompositeBehavior : FlockBehavior
    {
        public FlockBehavior[] behaviors;
        public float[] weights;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // handle data mismatch between behaviors and weights
            if (weights.Length != behaviors.Length)
            {
                Debug.LogError("Data mismatch in " + name, this);
                return Vector2.zero;
            }

            Vector2 move = Vector2.zero;

            for (int i = 0; i < behaviors.Length; i++)
            {
                Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];

                if (partialMove != Vector2.zero)
                {
                    // If partial move is greater than our weight, then normalize it so it's exactly the weight
                    if (partialMove.sqrMagnitude > weights[i] + weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    move += partialMove;
                }
            }
            return move;
        }
    }
}