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

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }



        void OnTriggerEnter2D(Collider2D other)
        {
            if (mask == (mask | (1 << other.gameObject.layer)))
            {
                Debug.Log("consumed");
                ICanConsume canConsume = other.GetComponent<ICanConsume>();
                canConsume.Consume(itemName);
                //rb.DOMove(other.transform.position, 3);
                // Could do other things like fly item towards it
                StartCoroutine(MoveTowardsPlayer(other.transform));
            }
        }

        IEnumerator MoveTowardsPlayer(Transform destination)
        {
            Tween moveItem = DOTweenModulePhysics2D.DOMove(rb, destination.position, 3, true);
            yield return moveItem;
            Destroy(gameObject);
        }
    }
}

