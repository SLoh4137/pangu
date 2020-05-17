using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class FlockManager : Singleton<FlockManager>
    {
        public Flock UnclaimedFlock;
        private List<FlockAgent> allAgents;
        private List<FlockAgent> agentsToAdd;
        private bool hasAgentsToRemove;
        private uint idCounter = 0;

        #region lifecycle
        void Awake()
        {
            allAgents = new List<FlockAgent>();
            agentsToAdd = new List<FlockAgent>();

            Flock flockPrefab = GameAssets.Instance.UnclaimedFlock;
            UnclaimedFlock = Instantiate(flockPrefab, transform.position, transform.rotation, transform);
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

            if(hasAgentsToRemove)
            {
                allAgents.RemoveAll(MarkedForDeletion);
                hasAgentsToRemove = false;
            }

            foreach (FlockAgent agent in allAgents)
            {
                if(agent == null)
                {
                    hasAgentsToRemove = true;
                } else {
                    agent.AgentFlock.UpdateAgent(agent);
                }
                
            }
        }
        #endregion lifecycle

        public void AddAgent(FlockAgent agent)
        {
            agentsToAdd.Add(agent);
        }

        public void RemoveAgent(FlockAgent agent)
        {
            agent.transform.parent = transform;
            agent.markedForDeletion = true;
            agent.ChangeFlock(UnclaimedFlock);
            hasAgentsToRemove = true;
        }

        public uint GetNextID()
        {
            return idCounter++;
        }

        private static bool MarkedForDeletion(FlockAgent agent)
        {
            if(agent == null) return true;
            if(agent.markedForDeletion) 
            {
                agent.DestroyAgent();
                return true;
            }
            return false;
        }
    }
}

