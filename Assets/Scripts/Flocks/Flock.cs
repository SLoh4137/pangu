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
        #endregion publicvars

        #region privatevars
        private List<FlockAgent> agents;
        private float squareMaxSpeed;
        private float squareNeighborRadius;
        private float squareAvoidanceRadius;
        #endregion privatevars

        #region getters
        public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
        #endregion getters

        #region lifecycle
        // Start is called before the first frame update
        void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
            agents = new List<FlockAgent>();

            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                //FOR DEMO ONLY
                //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

                Vector2 move = behavior.CalculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
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
                agents.Add(newAgent);
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
    }
}

