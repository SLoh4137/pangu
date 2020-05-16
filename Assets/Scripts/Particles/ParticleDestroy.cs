using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class ParticleDestroy : MonoBehaviour
    {
        public ParticleSystem pSystem;   
        private float destroyTime;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(pSystem.main.duration);
            destroyTime = Time.time + pSystem.main.duration;
        }

        void Update()
        {
            if(destroyTime <= Time.time)
            {
                Destroy(gameObject);
            }
        }

    }
}

