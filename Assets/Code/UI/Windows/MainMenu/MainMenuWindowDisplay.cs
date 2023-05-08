using System;
using Code.UI.WindowsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.MainMenu
{
    public class MainMenuWindowDisplay : WindowDisplay
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueGameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        public bool ContinueButtonInteractable
        {
            set => continueGameButton.interactable = value;
        }
        
        public event Action OnNewGameButtonClick;
        public event Action OnContinueGameButtonClick;
        public event Action OnSettingsButtonClick;
        public event Action OnExitButtonClick;

        private void OnNewGameButtonClicked()
        {
            OnNewGameButtonClick?.Invoke();
        }

        private void OnContinueGameButtonClicked()
        {
            OnContinueGameButtonClick?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            OnSettingsButtonClick?.Invoke();
        }

        private void OnExitButtonClicked()
        {
            OnExitButtonClick?.Invoke();
        }
        
        public override void Show()
        {
            base.Show();
            newGameButton.onClick.AddListener(OnNewGameButtonClicked);
            continueGameButton.onClick.AddListener(OnContinueGameButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public override void Hide()
        {
            base.Hide();
            newGameButton.onClick.RemoveListener(OnNewGameButtonClicked);
            continueGameButton.onClick.RemoveListener(OnContinueGameButtonClicked);
            settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }
    }
}