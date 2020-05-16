using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace pangu
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ItemBehavior : MonoBehaviour
    {
        public ItemName itemName;
        public LayerMask mask;
        private Rigidbody2D rb;
        private ICanConsume target;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (target != null)
            {
                if (Vector2.Distance(transform.position, target.transform.position) <= 2)
                {
                    Debug.Log("consumed");
                    target.Consume(itemName);
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (mask == (mask | (1 << other.gameObject.layer)))
            {
                ICanConsume canConsume = other.GetComponent<ICanConsume>();
                if(canConsume != null)
                {
                    target = canConsume;
                }
            }
        }

        // IEnumerator MoveTowardsPlayer(Transform destination)
        // {
        //     Tween moveItem = DOTweenModulePhysics2D.DOMove(rb, destination.position, 3, true);
        //     yield return moveItem;
        //     Destroy(gameObject);
        // }
    }
}

