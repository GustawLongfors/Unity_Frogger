using System;

namespace Code.Timers
{
    public interface ITimer
    {
        void Start();
        void Stop();
        void Restart();
        event Action<TimeSpan> OnTick;
        event Action OnStop;
    }
}