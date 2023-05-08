using Code.DataManagement;
using Code.UI.WindowsSystem;

namespace Code.UI.Windows.MainMenu
{
    public class SettingsWindow : Window<SettingsWindowDisplay>
    {
        private GameSettingsManager settingsManager;
        
        private void Awake()
        {
            settingsManager = FindObjectOfType<GameSettingsManager>();
            Display.OnBackButtonClick += Display_OnBackButtonClick;
            Display.OnMusicVolumeValueChange += Display_OnMusicVolumeValueChange;
            Display.OnSFXVolumeValueChange += Display_OnSFXVolumeValueChange;
        }

        public override void Open()
        {
            Display.Init(settingsManager.SettingsData);
            base.Open();
        }

        private void Display_OnBackButtonClick()
        {
            SaveLoadManager.Save();
            WindowsManager.CloseCurrentWindow();
        }

        private void Display_OnMusicVolumeValueChange(float value)
        {
            settingsManager.SettingsData.MusicVolume = value;
        }

        private void Display_OnSFXVolumeValueChange(float value)
        {
            settingsManager.SettingsData.SfxVolume = value;
        }
    }
}