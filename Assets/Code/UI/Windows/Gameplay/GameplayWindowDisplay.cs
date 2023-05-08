using System;
using Code.UI.WindowsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Gameplay
{
    public class GameplayWindowDisplay : WindowDisplay
    {
        [SerializeField] private TextMeshProUGUI currentLevelText;
        [SerializeField] private Button pauseButton;
        [SerializeField] private GameObject countdownOverlay;

        public int CurrentLevel
        {
            set => currentLevelText.SetText($"Level : {value}");
        }

        public bool CountdownOverlayActive
        {
            set => countdownOverlay.SetActive(value);
        }

        public event Action OnPauseButtonClicked;

        private void OnPauseButtonClick()
        {
            OnPauseButtonClicked?.Invoke();
        }

        public override void Show()
        {
            base.Show();
            pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        public override void Hide()
        {
            base.Hide();
            pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }
    }
}
