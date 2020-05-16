using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace pangu
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public TMP_Text text;
        
        public void InitHealth(int maxHealth)
        {
            SetMaxHealth(maxHealth);
            SetHealth(maxHealth);
        }

        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
            SetText(health);
        }

        private void SetText(int health)
        {
            text.SetText(health + "/" + slider.maxValue);
        }
    }
}

