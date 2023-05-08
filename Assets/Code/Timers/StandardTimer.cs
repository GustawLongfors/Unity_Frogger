using System;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Timers
{
    public class StandardTimer : ITimer
    {
        private readonly TimeSpan interval;
        private CancellationTokenSource cancellationTokenSource;
        private Task timerTask;
        private bool isRunning;
        private TimeSpan elapsedTime;

        public event Action<TimeSpan> OnTick;
        public event Action OnStop;

        public StandardTimer(TimeSpan interval)
        {
            this.interval = interval;
        }

        public async void Start()
        {
            if (isRunning) return;

            isRunning = true;
            cancellationTokenSource = new CancellationTokenSource();
            timerTask = RunTimerAsync(cancellationTokenSource.Token);
            await timerTask;
        }

        public void Stop()
        {
            isRunning = false;
            cancellationTokenSource?.Cancel();
            OnStop?.Invoke();
        }

        public void Restart()
        {
            Stop();
            elapsedTime = TimeSpan.Zero;
            Start();
        }

        private async Task RunTimerAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(interval, cancellationToken);
                    elapsedTime = elapsedTime.Add(interval);
                    OnTick?.Invoke(elapsedTime);
                }
            }
            catch(TaskCanceledException)
            {
                //We don't do anything here. This will occur when stopping the timer
            }
        }
    }
}