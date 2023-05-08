namespace Code.UI.Elements.Timer
{
    using System;
    using TMPro;
    using UnityEngine;

    public class TimeCounterDisplay : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI timerText;

        public virtual void UpdateTime(TimeSpan time)
        {
            string formattedTime = time.Hours < 1
                ? $"{time.Minutes:D2}:{time.Seconds:D2}"
                : $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";

            timerText.text = formattedTime;
        }

        public virtual void Reset()
        {
            timerText.text = "00:00";
        }
    }
}