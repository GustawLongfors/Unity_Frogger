using System;
using Code.UI.WindowsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Common
{
    public class ChangeNameWindowDisplay : WindowDisplay
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button acceptButton;

        public string PlayerName
        {
            set => nameInputField.SetTextWithoutNotify(value);
        }
        public event Action OnCancelButtonClicked;
        public event Action<string> OnAcceptButtonClicked;

        private void OnCancelButtonClick()
        {
            OnCancelButtonClicked?.Invoke();
        }

        private void OnAcceptButtonClick()
        {
            OnAcceptButtonClicked?.Invoke(nameInputField.text);
        }

        public override void Show()
        {
            base.Show();
            cancelButton.onClick.AddListener(OnCancelButtonClick);
            acceptButton.onClick.AddListener(OnAcceptButtonClick);
        }

        public override void Hide()
        {
            base.Hide();
            cancelButton.onClick.RemoveListener(OnCancelButtonClick);
            acceptButton.onClick.RemoveListener(OnAcceptButtonClick);
        }
    }
}