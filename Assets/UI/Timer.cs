using UnityEngine;
using TMPro;

namespace pangu
{
    
    public class Timer : MonoBehaviour
    {
        public TMP_Text text;

        public void SetTime(float ElapsedTime)
        {
            int minutes = (int) ElapsedTime / 60;
            int seconds = (int) ElapsedTime - minutes;

            text.SetText(string.Format("{0,1:0}:{1,2:00}", minutes, seconds));
        } 
    }
}

