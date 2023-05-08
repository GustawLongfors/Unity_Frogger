using System;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Timers
{
    public class CountdownTimer : ITimer
    {
        private readonly TimeSpan interval;
        private readonly TimeSpan totalTime;
        private CancellationTokenSource cancellationTokenSource;
        private Task timerTask;
        private bool isRunning;
        private TimeSpan remainingTime;

        public event Action<TimeSpan> OnTick;
        public event Action OnStop;

        public CountdownTimer(TimeSpan interval, TimeSpan totalTime)
        {
            this.interval = interval;
            this.totalTime = totalTime;
            this.remainingTime = totalTime;
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
        }

        public void Restart()
        {
            Stop();
            remainingTime = totalTime;
            Start();
        }

        private async Task RunTimerAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(interval, cancellationToken);
                    remainingTime = remainingTime.Subtract(interval);

                    if (remainingTime <= TimeSpan.Zero)
                    {
                        remainingTime = TimeSpan.Zero;
                        OnStop?.Invoke();
                        OnTick?.Invoke(totalTime);
                        Stop();
                    }
                    else
                    {
                        OnTick?.Invoke(remainingTime);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // We don't do anything here. This will occur when stopping the timer
            }
        }
    }
}