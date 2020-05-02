using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
    public class SameFlockFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filtered = new List<Transform>();
            foreach (Transform item in original)
            {
                FlockAgent flockAgent = item.GetComponent<FlockAgent>();
                if (flockAgent != null && agent.AgentFlock == flockAgent.AgentFlock)
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}

