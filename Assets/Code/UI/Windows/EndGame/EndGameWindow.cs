using System;
using Code.Scenes;
using Code.UI.WindowsSystem;

namespace Code.UI.Windows.EndGame
{
    public class EndGameWindow : Window<EndGameWindowDisplay>
    {
        private ScenesManager scenesManager;
        private void Awake()
        {
            scenesManager = FindObjectOfType<ScenesManager>();
            Display.OnBackToMenuButtonClicked += Display_OnBackToMenuButtonClicked;
        }

        private void Display_OnBackToMenuButtonClicked()
        {
            scenesManager.Load(SceneNames.MAIN_MENU);
        }
    }
}
