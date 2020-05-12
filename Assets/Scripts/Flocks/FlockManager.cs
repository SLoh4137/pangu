using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class FlockManager : Singleton<FlockManager>
    {
        private List<FlockAgent> allAgents;
        private List<FlockAgent> agentsToAdd;
        private HashSet<FlockAgent> agentsToRemove;

        #region lifecylce
        void Awake()
        {
            allAgents = new List<FlockAgent>();
            agentsToAdd = new List<FlockAgent>();
            agentsToRemove = new HashSet<FlockAgent>();
        }

        void Update()
        {
            if (agentsToAdd.Count > 0)
            {
                foreach (FlockAgent agent in agentsToAdd)
                {
                    allAgents.Add(agent);
                }
                agentsToAdd.Clear();
            }

            foreach (FlockAgent agent in allAgents)
            {
                agent.AgentFlock.UpdateAgent(agent);
            }

            if (agentsToRemove.Count > 0)
            {
                foreach (FlockAgent agent in agentsToRemove)
                {
                    allAgents.Remove(agent);
                    agent.DestroyAgent();
                }
                agentsToRemove.Clear();
            }
        }
        #endregion lifecylce

        public void AddAgent(FlockAgent agent)
        {
            agentsToAdd.Add(agent);
        }

        public void RemoveAgent(FlockAgent agent)
        {
            agentsToRemove.Add(agent);
        }
    }
}

