using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterStats))]
    public class PlayerControl : MonoBehaviour, ICharacter, ICanConsume
    {
        #region publicVars
        public CharacterStats Stats { get; set; }
        public GameObject Hurtbox;
        public GameObject Hitbox;
        public GameObject gameOverText;
        public HealthBar healthBar;

        [Header("Input")]
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;
        public bool FacingRight;
        public bool Attacking;

        [Header("Character Feel")]
        public float GravityMultiplier = 2.5f;
        public float PullMultiplier = 2.5f;

        [Header("Wall Jump")]
        public float wallJumpTime = 0.2f;
        public float wallSlideSpeed = 0.3f;
        public float wallDistance;
        private float jumpTime;

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

        public event Action<ICharacter> onAttack;
        public event Action<ICharacter> onDefend;


        // Function Getters/Setters
        private Animator animator;
        public Animator Animator { get { return animator; } }
        private Rigidbody2D rb;
        public Rigidbody2D Rigidbody
        {
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

        void Start()
        {
            healthBar.InitHealth(Stats.MaxHealth);
        }

        void Update()
        {
            animator.SetFloat(PlayerTransition.VelocityY.ToString(), Rigidbody.velocity.y);
            FlipIdle(MoveHorizontal == 0);
        }

        void FlipIdle(bool isIdle)
        {
            animator.SetBool(PlayerTransition.isIdle.ToString(), isIdle);
            animator.SetBool(PlayerTransition.isWalk.ToString(), !isIdle);
        }

        void FixedUpdate()
        {
            if (rb.velocity.y < 0f)
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
            int damageTaken = (int)Mathf.Clamp(damage - (int)Stats.Defense.Value, 0, float.MaxValue);
            animator.SetTrigger(PlayerTransition.Hurt.ToString());
            Stats.Health -= damageTaken;
            healthBar.SetHealth(Stats.Health);

            if (onDefend != null)
            {
                onDefend(this);
            }

            if(Stats.Health <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            animator.SetBool(PlayerTransition.isDead.ToString(), true);
            gameOverText.SetActive(true);
            Hitbox.SetActive(false);
        }

        public void DealDamage(ICharacter character)
        {
            int damage = Mathf.CeilToInt(Stats.AttackDamage.Value);
            //Stats.AttackRange += 1;
            character.TakeDamage(damage);
            DamagePopup.Create(character.transform.position, damage);

            if (onAttack != null)
            {
                onAttack(character);
            }
        }
        #endregion ICharacter

        #region ICanConsume
        public void Consume(ItemName itemName)
        {
            Stats.AddItem(itemName);
        }

        #endregion ICanConsume

        #region DetectGround
        public bool DetectGround()
        {
            foreach (GameObject sphere in GroundDetectionSpheres)
            {
                RaycastHit2D hit = Physics2D.Raycast(sphere.transform.position, Vector3.down, GroundDetectionDistance, groundLayers);
                Debug.DrawRay(sphere.transform.position, Vector3.down * GroundDetectionDistance, Color.black);
                if (hit.collider != null)
                {
                    jumpTime = Time.time + wallJumpTime;
                    return true;
                }
            }
            return false;
        }

        private GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject sphere = Instantiate(GroundDetectionSpherePrefab, pos, Quaternion.identity, transform);
            return sphere;
        }
        #endregion

        #region Movement
        public void MoveWalk()
        {
            Rigidbody.velocity = new Vector2(Stats.Speed.Value * MoveHorizontal, Rigidbody.velocity.y);
        }

        public void MoveWalkAir()
        {
            Rigidbody.velocity = new Vector2(Stats.AirSpeed.Value * MoveHorizontal, Rigidbody.velocity.y);
        }

        public void MoveCrouchWalk()
        {
            Rigidbody.velocity = new Vector2(Stats.Speed.Value * MoveHorizontal, Rigidbody.velocity.y);
        }

        public void MoveJump()
        {
            Rigidbody.AddForce(Vector2.up * Stats.JumpForce.Value);
        }

        public bool CanJump()
        {
            return Jump && (jumpTime >= Time.time || DetectGround());
        }

        public bool CanWallJump()
        {
            return Jump && CheckWallSliding();
        }

        public bool CheckWallSliding()
        {
            return CheckWallSliding(DetectGround());
        }

        public bool CheckWallSliding(bool isGrounded)
        {
            if(isGrounded && jumpTime < Time.time) return false;

            int direction = FacingRight ? 1 : -1;
            RaycastHit2D wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance * direction, 0), wallDistance, groundLayers);
            Debug.DrawRay(transform.position, new Vector2(wallDistance * direction, 0), Color.blue);

            if(wallCheckHit && MoveHorizontal != 0)
            {
                jumpTime = Time.time + wallJumpTime;
                return true;
            }
            else if (jumpTime < Time.time)
            {
                return false;
            } 

            return true;
        }

        public void MoveWallSlide()
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Mathf.Clamp(Rigidbody.velocity.y, wallSlideSpeed, float.MaxValue));
        }

        #endregion


        public void Flip()
        {
            FacingRight = !FacingRight;
            transform.localScale = transform.localScale * flipVector; // flips by multiplying x by -1
        }



    }
}

