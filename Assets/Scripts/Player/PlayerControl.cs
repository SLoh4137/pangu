using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterStats))]
    public class PlayerControl : MonoBehaviour, ICharacter 
    {
        #region publicVars
        public CharacterStats Stats { get; set; }

        [Header("Input")]
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;
        public bool FacingRight;
        public bool Attacking;

        [Header("Character Feel")]
        public float GravityMultiplier = 2.5f;
        public float PullMultiplier = 2.5f;

        [Header("Collision Detection")]
        public GameObject GroundDetectionSpherePrefab;
        public float GroundDetectionGranularity;
        public List<GameObject> GroundDetectionSpheres
        {
            get { return _groundDetectionSpheres; }
        }
        public LayerMask groundLayers;
        public float GroundDetectionDistance = .25f;
        #endregion publicVars

        private List<GameObject> _groundDetectionSpheres;
        private Vector2 flipVector = new Vector2(-1, 1);
        

        // Function Getters/Setters
        private Animator animator;
        public Animator Animator { get { return animator; }}
        private Rigidbody2D rb;
        public Rigidbody2D Rigidbody {
            get { return rb; }
        }

        #region lifecycle
        void Awake()
        {
            FacingRight = true;
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            Stats = GetComponent<CharacterStats>();

            Collider2D collider = GetComponent<Collider2D>();

            float bottom = collider.bounds.center.y - collider.bounds.extents.y;
            float left = collider.bounds.center.x - collider.bounds.extents.x;
            float right = collider.bounds.center.x + collider.bounds.extents.x;
            _groundDetectionSpheres = new List<GameObject>();
            

            if (_groundDetectionSpheres != null)
            {
                // A prefab given, so let's create ground detection!
                GameObject bottomLeft = CreateEdgeSphere(new Vector3(left, bottom, 0));
                GameObject bottomRight = CreateEdgeSphere(new Vector3(right, bottom, 0));

                _groundDetectionSpheres.Add(bottomLeft);
                _groundDetectionSpheres.Add(bottomRight);

                float distanceBetween = (bottomLeft.transform.position - bottomRight.transform.position).magnitude / GroundDetectionGranularity;
                for (int i = 1; i < GroundDetectionGranularity - 1; i++) 
                {
                    Vector3 pos = bottomLeft.transform.position + Vector3.right * distanceBetween * i;

                    GameObject sphere = CreateEdgeSphere(pos);
                    _groundDetectionSpheres.Add(sphere);
                }
            }

        }

        void Update()
        {
            animator.SetFloat(PlayerTransition.VelocityY.ToString(), rb.velocity.y);
        }

        void FixedUpdate() {
            if(rb.velocity.y < 0f)
            {
                rb.velocity += Vector2.down * GravityMultiplier;
            }
            else if (rb.velocity.y > 0f && !Jump)
            {
                rb.velocity += Vector2.down * PullMultiplier;
            }
        }

        #endregion lifecycle

        #region ICharacter
        public void TakeDamage(int damage) 
        {
            Stats.Health -= damage;
        }

        public void DealDamage(ICharacter character)
        {
            int damage = Mathf.CeilToInt(Stats.AttackDamage.Value);
            //Stats.AttackRange += 1;
            character.TakeDamage(damage);
        }
        #endregion

        public bool DetectGround() {
            foreach(GameObject sphere in GroundDetectionSpheres) 
            {
                RaycastHit2D hit = Physics2D.Raycast(sphere.transform.position, Vector3.down, GroundDetectionDistance, groundLayers);
                Debug.DrawRay(sphere.transform.position, Vector3.down * GroundDetectionDistance, Color.black);
                if (hit.collider != null)
                { 
                    return true;
                }
            }
            return false;
        }

        public void Flip() 
        {
            FacingRight = !FacingRight;
            transform.localScale = transform.localScale * flipVector; // flips by multiplying x by -1
        }

        private GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject sphere = Instantiate(GroundDetectionSpherePrefab, pos, Quaternion.identity, transform);
            return sphere;
        }

    }
}

