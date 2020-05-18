using UnityEngine;
using TMPro;

namespace pangu
{
    
    public class Timer : MonoBehaviour
    {
        public TMP_Text text;
        public Gradient colorGradient;
        public float maxTime;

        public void SetTime(float ElapsedTime)
        {
            int minutes = (int) ElapsedTime / 60;
            int seconds = (int) ElapsedTime % 60;

            text.SetText(string.Format("{0,1:0}:{1,2:00}", minutes, seconds));
            text.color = colorGradient.Evaluate(Mathf.Clamp01(ElapsedTime / maxTime));
        } 
    }
}

