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

        private Queue<TextToShow> queue;

        struct TextToShow {
            public string name;
            public string description;
            public TextToShow(string _name, string _description)
            {
                name = _name;
                description = _description;
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
            textShown = false;
            disappearTimer = 0;
            textColor = nameText.color;
            queue = new Queue<TextToShow>();
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
                        Next();
                    }
                }
            }
        }

        public void Next()
        {
            if(queue.Count == 0) return;

            TextToShow text = queue.Dequeue();
            DisplayText(text.name, text.description);
        }

        public void SetItemText(string itemName, string description)
        {
            if(textShown)
            {
                queue.Enqueue(new TextToShow(itemName, description));
            }
            else
            {
                DisplayText(itemName, description);
            }
        }

        private void DisplayText(string itemName, string description)
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

