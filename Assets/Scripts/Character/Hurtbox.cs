using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class Hurtbox : MonoBehaviour
    {
        private ICharacter character;
        public LayerMask mask;

        private float pastSize;
        // Start is called before the first frame update
        void Awake()
        {
            character = GetComponentInParent<ICharacter>();
        }
        void Start()
        {
            pastSize = character.Stats.AttackRange.Value;
            transform.localScale *= pastSize;
        }

        void Update()
        {
            if (character.Stats.AttackRange.Value != pastSize)
            {
                pastSize = character.Stats.AttackRange.Value;
                transform.localScale *= pastSize;
            }
        }

        // Need to deal with some way to make hurtbox bigger

        void OnTriggerEnter2D(Collider2D other)
        {

            // If has colliding layer
            if (mask == (mask | (1 << other.gameObject.layer)))
            {
                ReferenceCharacter otherRef = other.GetComponent<ReferenceCharacter>();
                if (otherRef != null && otherRef.Character != null)
                {
                    character.DealDamage(otherRef.Character);
                }
            }
        }
    }
}