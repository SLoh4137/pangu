using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class ItemBehavior : MonoBehaviour
    {
        public ItemName itemName;
        public LayerMask mask;
        
        private void OnTriggerEnter(Collider other) {
            if (mask == (mask | (1 << other.gameObject.layer)))
            {
                ICanConsume canConsume = other.GetComponent<ICanConsume>();
                canConsume.Stats.AddItem(itemName);
            }
        }
    }
}

