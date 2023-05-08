using System;
using Code.UI.WindowsSystem;

namespace Code.UI.Windows.Common
{
    public class ChangeNameWindow : Window<ChangeNameWindowDisplay>
    {
        public event Action<string> OnNameChanged;
        private void Awake()
        {
            Display.OnCancelButtonClicked += Display_OnCancelButtonClicked;
            Display.OnAcceptButtonClicked += Display_OnAcceptButtonClicked;
        }

        private void Display_OnCancelButtonClicked()
        {
            WindowsManager.CloseCurrentWindow();
        }

        private void Display_OnAcceptButtonClicked(string playerName)
        {
            WindowsManager.CloseCurrentWindow();
            OnNameChanged?.Invoke(playerName);
        }

        public void Init(string playerName)
        {
            Display.PlayerName = playerName;
        }
    }
}