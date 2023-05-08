using System;
using Code.UI.WindowsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.EndGame
{
    public class EndGameWindowDisplay : WindowDisplay
    {
        [SerializeField] private Button backToMenuButton;

        public event Action OnBackToMenuButtonClicked;

        private void OnBackToMenuButtonClick()
        {
            OnBackToMenuButtonClicked?.Invoke();
        }

        public override void Show()
        {
            base.Show();
            backToMenuButton.onClick.AddListener(OnBackToMenuButtonClick);
        }

        public override void Hide()
        {
            base.Hide();
            backToMenuButton.onClick.RemoveListener(OnBackToMenuButtonClick);
        }
    }
}
