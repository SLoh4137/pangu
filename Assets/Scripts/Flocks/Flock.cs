using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class Flock : MonoBehaviour
    {
        #region publicvars
        public FlockBehavior behavior;
        public FlockAgent agentPrefab;

        public int startingCount = 250;
        const float AgentDensity = 0.08f;

        public float driveFactor = 10f;
        public float maxSpeed = 5f;
        public float neighborRadius = 1.5f;
        public float avoidanceRadiusMultiplier = 0.5f;
        public Color color;
        #endregion publicvars

        #region privatevars
        private HashSet<FlockAgent> agents;
        private float squareMaxSpeed;
        private float squareNeighborRadius;
        private float squareAvoidanceRadius;
        #endregion privatevars

        #region getters
        public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
        #endregion getters

        #region lifecycle
        // Start is called before the first frame update
        void Awake()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
            agents = new HashSet<FlockAgent>();
        }

        void Start()
        {
            Initialize();
        }

        // Update is called once per frame

        public void UpdateAgent(FlockAgent agent)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }

        private void OnDestroy()
        {
            foreach (FlockAgent agent in agents)
            {
                // For now destroys every agent, can implement logic to only destroy a portion and release the rest later
                FlockManager.Instance.RemoveAgent(agent);
            }
        }
        #endregion lifecycle

        private void Initialize()
        {
            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    Random.insideUnitCircle * startingCount * AgentDensity,
                    Quaternion.Euler(Vector2.up * Random.Range(0f, 360f)),
                    transform
                );

                newAgent.name = "Agent " + i;

                newAgent.Initialize(this);

                FlockManager.Instance.AddAgent(newAgent);
            }
        }

        private List<Transform> GetNearbyObjects(FlockAgent agent)
        {
            List<Transform> context = new List<Transform>();
            Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
            foreach (Collider2D c in contextColliders)
            {
                if (c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }

            return context;
        }

        public void RemoveAgent(FlockAgent agent)
        {
            agents.Remove(agent);
        }

        public void AddAgent(FlockAgent agent)
        {
            agents.Add(agent);
        }

        public bool IsAgentStolen(FlockAgent agent)
        {
            return !agents.Contains(agent);
        }

        public void StealAgentFromFlock(FlockAgent agentToSteal, Flock flockToStealFrom)
        {
            // If agent already in flock, no need to steal
            if (agents.Contains(agentToSteal))
                return;

            flockToStealFrom.RemoveAgent(agentToSteal);
            AddAgent(agentToSteal);
            agentToSteal.ChangeFlock(this);
        }
    }
}

