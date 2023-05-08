using Code.Levels;
using Code.Pause;
using Code.UI.Elements.Timer;
using Code.UI.WindowsSystem;
using UnityEngine;

namespace Code.UI.Windows.Gameplay
{
    public class GameplayWindow : Window<GameplayWindowDisplay>
    {
        [SerializeField] private TimeCounterElement timeCounterElement;
        [SerializeField] private TimeCounterElement countdownTimeCounterElement;

        private LevelsController levelsController;

        private void Awake()
        {
            Display.OnPauseButtonClicked += Display_OnPauseButtonClicked;
            levelsController = FindObjectOfType<LevelsController>();
        }

        private void Start()
        {
            timeCounterElement.Init(levelsController.Timer);
            countdownTimeCounterElement.Init(levelsController.CountdownTimer);
        }

        public override void Open()
        {
            base.Open();
            levelsController.OnLevelLoaded += OnLevelLoaded;
            levelsController.CountdownTimer.OnStop += CountdownTimer_OnStop;
            levelsController.Timer.OnStop += Timer_OnStop;
        }

        public override void Close()
        {
            base.Close();
            if (levelsController == null) return;
            levelsController.OnLevelLoaded -= OnLevelLoaded;
            levelsController.CountdownTimer.OnStop -= CountdownTimer_OnStop;
            levelsController.Timer.OnStop -= Timer_OnStop;
        }

        private void OnLevelLoaded(int levelIndex, LevelData levelData)
        {
            Display.CurrentLevel = levelIndex;
            Display.CountdownOverlayActive = true;
        }
        
        private void Display_OnPauseButtonClicked()
        {
            PauseManager.Pause();
            WindowsManager.OpenWindow<PauseWindow>();
        }

        private void CountdownTimer_OnStop()
        {
            Display.CountdownOverlayActive = false;
        }

        private void Timer_OnStop()
        {
            timeCounterElement.Reset();
        }

        private void Update() {
            if (levelsController.countdownTimerFinished == true) {
                Display.CountdownOverlayActive = false;
            }
        }
    }
}
