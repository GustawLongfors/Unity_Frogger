using System;
using Code.DataManagement;
using Code.UI.Elements;
using Code.UI.WindowsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.MainMenu
{
    public class SettingsWindowDisplay : WindowDisplay
    {
        [SerializeField] private Button backButton;
        [SerializeField] private SettingSliderElement musicVolumeSliderElement;
        [SerializeField] private SettingSliderElement sfxVolumeSliderElement;
        
        private Settings settingsData;

        public event Action OnBackButtonClick;
        public event Action<float> OnMusicVolumeValueChange;
        public event Action<float> OnSFXVolumeValueChange;

        public void Init(Settings settingsData)
        {
            this.settingsData = settingsData;
        }

        public override void Show()
        {
            base.Show();
            backButton.onClick.AddListener(OnBackButtonClicked);
            musicVolumeSliderElement.OnSliderValueChange += OnMusicVolumeValueChange;
            sfxVolumeSliderElement.OnSliderValueChange += OnSFXVolumeValueChange;
            musicVolumeSliderElement.Init(0f,1f,settingsData.MusicVolume);
            sfxVolumeSliderElement.Init(0f,1f,settingsData.SfxVolume);
        }

        public override void Hide()
        {
            base.Hide();
            backButton.onClick.RemoveListener(OnBackButtonClicked);
            musicVolumeSliderElement.OnSliderValueChange -= OnMusicVolumeValueChange;
            sfxVolumeSliderElement.OnSliderValueChange -= OnSFXVolumeValueChange;
        }

        private void OnBackButtonClicked()
        {
            OnBackButtonClick?.Invoke();
        }
    }
}