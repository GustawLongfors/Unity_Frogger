using System;

namespace Code.UI.Elements.Timer
{
    public class SimpleTimeCounterDisplay : TimeCounterDisplay
    {
        private const string DEFAULT_VALUE = "3";
        public override void UpdateTime(TimeSpan time)
        {
            string formattedTime = $"{time.TotalSeconds}";
            timerText.text = formattedTime;
        }

        public override void Reset()
        {
            timerText.text = DEFAULT_VALUE;
        }
    }
}