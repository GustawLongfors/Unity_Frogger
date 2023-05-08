using Code.Pause;
using Code.Timers;

namespace Code.UI.Elements.Timer
{
    using System;
    using UnityEngine;

    public class TimeCounterElement : MonoBehaviour, IPausable
    {
        [SerializeField] private TimeCounterDisplay display;
        private ITimer timer;

        private void Awake()
        {
            PauseManager.RegisterPausable(this);
        }

        private void OnDestroy()
        {
            timer.OnTick -= UpdateTime;
            PauseManager.UnregisterPausable(this);
        }

        private void UpdateTime(TimeSpan timeElapsed)
        {
            display.UpdateTime(timeElapsed);
        }

        public void Reset()
        {
            display.Reset();
        }
        
        public void Init(ITimer timer)
        {
            this.timer = timer;
            timer.OnTick += UpdateTime;
        }

        public void SetPause(bool paused)
        {
            if(paused) timer.Stop();
            else timer.Start();
        }
    }
}