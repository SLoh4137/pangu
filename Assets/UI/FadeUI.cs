using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pangu
{
    public class FadeUI : MonoBehaviour
    {
        public CanvasGroup group;
        public float lifetime;
        public float disappearSpeed;

        private float disappearTimer;
        void Start()
        {
            disappearTimer = lifetime;
        }
        // Update is called once per frame
        void Update()
        {
            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                group.alpha -= disappearSpeed * Time.deltaTime;
                if (group.alpha < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

