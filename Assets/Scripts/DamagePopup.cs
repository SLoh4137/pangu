using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace pangu
{
    public class DamagePopup : MonoBehaviour
    {
        public static DamagePopup Create(Vector3 position, int damageAmount)
        {
            Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
            DamagePopup popup = damagePopupTransform.GetComponent<DamagePopup>();
            popup.Setup(damageAmount);
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

        void Setup(int damageAmount)
        {
            textMesh.SetText(damageAmount.ToString());
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

