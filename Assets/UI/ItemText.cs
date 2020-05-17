using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace pangu
{
    public class ItemText : MonoBehaviour
    {

        public TMP_Text nameText;
        public TMP_Text descriptionText;
        public float lifetime;
        public float disappearSpeed;

        private float disappearTimer;
        private bool textShown;
        private Color textColor;

        // Start is called before the first frame update
        void Start()
        {
            textShown = false;
            disappearTimer = 0;
            textColor = nameText.color;
        }

        // Update is called once per frame
        void Update()
        {
            if(textShown)
            {
                disappearTimer -= Time.deltaTime;
                if(disappearTimer < 0)
                {
                    textColor.a -= disappearSpeed * Time.deltaTime;
                    nameText.color = textColor;
                    descriptionText.color = textColor;
                    if(textColor.a < 0)
                    {
                        textShown = false;
                    }
                }
            }
        }

        public void SetItemText(string itemName, string description)
        {
            nameText.SetText(itemName);
            descriptionText.SetText(description);

            textColor.a = 1;
            nameText.color = textColor;
            descriptionText.color = textColor;

            disappearTimer = lifetime;
            textShown = true;
        }
    }
}

