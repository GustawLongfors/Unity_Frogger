using System;

namespace Code.Pause
{
    public static class PauseManager
    {
        private static event Action<bool> OnPauseStateChange;

        public static void Pause()
        {
            OnPauseStateChange?.Invoke(true);
        }

        public static void UnPause()
        {
            OnPauseStateChange?.Invoke(false);
        }

        public static void RegisterPausable(IPausable pausable)
        {
            OnPauseStateChange += pausable.SetPause;
        }

        public static void UnregisterPausable(IPausable pausable)
        {
            OnPauseStateChange -= pausable.SetPause;
        }
    }
}
