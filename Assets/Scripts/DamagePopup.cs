using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace pangu
{
    public class DamagePopup : MonoBehaviour
    {
        public static DamagePopup Create(Vector3 position, int damageAmount, Color color)
        {
            Vector3 jitterPos = position + (Vector3) Random.insideUnitCircle;
            Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, jitterPos, Quaternion.identity);
            DamagePopup popup = damagePopupTransform.GetComponent<DamagePopup>();
            popup.Setup(damageAmount, color);
            return popup;
        }

        private TextMeshPro textMesh;
        private float disappearTimer;
        private Color textColor;
        void Awake()
        {
            textMesh = GetComponent<TextMeshPro>();
            textColor = textMesh.color;
            disappearTimer = 0.5f;
        }

        void Setup(int damageAmount, Color color)
        {
            textMesh.SetText(damageAmount.ToString());
            textColor = color;
            textMesh.color = textColor;
        }

        void Update()
        {
            float moveYSpeed = 10f;
            transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
            disappearTimer -= Time.deltaTime;
            if(disappearTimer < 0)
            {
                float disappearSpeed = 5f;
                textColor.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if(textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}

