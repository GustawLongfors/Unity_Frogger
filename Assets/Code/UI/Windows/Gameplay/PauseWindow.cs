using System;
using Code.DataManagement;
using Code.Pause;
using Code.Scenes;
using Code.UI.Windows.Common;
using Code.UI.WindowsSystem;

namespace Code.UI.Windows.Gameplay
{
    public class PauseWindow : Window<PauseWindowDisplay>
    {
        private ScenesManager scenesManager;
        private GameSettingsManager settingsManager;

        private void Awake()
        {
            scenesManager = FindObjectOfType<ScenesManager>();
            settingsManager = FindObjectOfType<GameSettingsManager>();
            Display.OnBackToMenuButtonClicked += Display_OnBackToMenuButtonClicked;
            Display.OnBackToGameplayButtonClicked += Display_OnBackToGameplayButtonClicked;
            Display.OnChangeNameButtonClicked += Display_OnChangeNameButtonClicked;
            Display.OnMusicVolumeValueChange += Display_OnMusicVolumeValueChange;
            Display.OnSFXVolumeValueChange += Display_OnSFXVolumeValueChange;
        }

        private void Display_OnBackToMenuButtonClicked()
        {
            PauseManager.UnPause();
            SaveLoadManager.Save();
            scenesManager.Load(SceneNames.MAIN_MENU);
        }

        private void Display_OnBackToGameplayButtonClicked()
        {
            PauseManager.UnPause();
            SaveLoadManager.Save();
            WindowsManager.CloseCurrentWindow();
        }

        private void Display_OnChangeNameButtonClicked()
        {
            WindowsManager.OpenWindow<ChangeNameWindow>();
            var changeNameWindow = WindowsManager.GetWindow<ChangeNameWindow>();
            changeNameWindow.Init(settingsManager.PlayerData.Name);
            changeNameWindow.OnNameChanged -= OnPlayerNameChanged;
            changeNameWindow.OnNameChanged += OnPlayerNameChanged;
        }

        private void OnPlayerNameChanged(string playerName)
        {
            Display.PlayerName = playerName;
            settingsManager.PlayerData.Name = playerName;
        }
        
        private void Display_OnMusicVolumeValueChange(float value)
        {
            settingsManager.SettingsData.MusicVolume = value;
        }

        private void Display_OnSFXVolumeValueChange(float value)
        {
            settingsManager.SettingsData.SfxVolume = value;
        }

        public override void Open()
        {
            Display.Init(settingsManager.SettingsData);
            Display.PlayerName = settingsManager.PlayerData.Name;
            base.Open();
        }
    }
}