using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgent : MonoBehaviour
    {

        #region privatevars
        private Flock agentFlock;
        private Collider2D agentCollider;
        #endregion privatevars

        #region getters
        public Flock AgentFlock { get { return agentFlock; } }
        public Collider2D AgentCollider { get { return agentCollider; } }
        #endregion getters


        // Start is called before the first frame update
        void Start()
        {
            agentCollider = GetComponent<Collider2D>();
        }

        public void Initialize(Flock flock)
        {
            agentFlock = flock;
        }

        public void Move(Vector2 velocity)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
    }
}