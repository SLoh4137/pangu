using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu

{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PlayerController : CharacterControl
    {
        public LayerMask collideLayerMask;
        private CapsuleCollider2D _collider;


        void Awake()
        {
            _collider = GetComponent<CapsuleCollider2D>();
        }

        public override void CollisionDetection()
        {
            Collider2D[] hits = Physics2D.OverlapCapsuleAll(transform.position, _collider.size, _collider.direction, 0f, collideLayerMask);
            foreach (Collider2D hit in hits)
            {
                ColliderDistance2D colliderDistance = hit.Distance(_collider);
                if (colliderDistance.isOverlapped)
                {
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                }
            }
        }
    }
}

