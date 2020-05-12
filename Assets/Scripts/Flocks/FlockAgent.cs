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
        private SpriteRenderer spriteRenderer;
        #endregion privatevars

        #region getters
        public Flock AgentFlock { get { return agentFlock; }}
        public Collider2D AgentCollider { get { return agentCollider; } }
        #endregion getters


        // Start is called before the first frame update
        void Awake()
        {
            agentCollider = GetComponent<Collider2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Initialize(Flock flock)
        {
            agentFlock = flock;
            spriteRenderer.color = flock.color;
            gameObject.layer = flock.gameObject.layer;
        }

        public void Move(Vector2 velocity)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }

        public void ChangeFlock(Flock newFlock)
        {
            Initialize(newFlock);
            transform.parent = newFlock.transform;
        }

        public Vector2 ClosestPoint(Transform item) 
        {
            Collider2D itemCollider = item.GetComponent<Collider2D>();
            return itemCollider != null ? itemCollider.ClosestPoint(transform.position) : (Vector2) item.position;
        }

        public void DestroyAgent()
        {
            Destroy(gameObject);
        }
    }
}