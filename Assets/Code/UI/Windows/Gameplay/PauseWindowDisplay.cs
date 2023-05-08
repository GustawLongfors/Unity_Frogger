using System;
using Code.DataManagement;
using Code.UI.Elements;
using Code.UI.WindowsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Gameplay
{
    public class PauseWindowDisplay : WindowDisplay
    {
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private SettingSliderElement sfxVolumeSlider;
        [SerializeField] private SettingSliderElement musicVolumeSlider;
        [SerializeField] private Button backToMenuButton;
        [SerializeField] private Button backToGameplayButton;
        [SerializeField] private Button changeNameButton;
        
        private Settings settingsData;

        public string PlayerName
        {
            set => playerName.SetText(value);
        }

        public event Action OnBackToMenuButtonClicked;
        public event Action OnBackToGameplayButtonClicked;
        public event Action OnChangeNameButtonClicked;
        public event Action<float> OnMusicVolumeValueChange;
        public event Action<float> OnSFXVolumeValueChange;

        private void OnBackToMenuButtonClick()
        {
            OnBackToMenuButtonClicked?.Invoke();
        }

        private void OnBackToGameplayButtonClick()
        {
            OnBackToGameplayButtonClicked?.Invoke();
        }

        private void OnChangeNameButtonClick()
        {
            OnChangeNameButtonClicked?.Invoke();
        }

        public void Init(Settings settingsData)
        {
            this.settingsData = settingsData;
        }
        
        public override void Show()
        {
            base.Show();
            backToMenuButton.onClick.AddListener(OnBackToMenuButtonClick);
            backToGameplayButton.onClick.AddListener(OnBackToGameplayButtonClick);
            changeNameButton.onClick.AddListener(OnChangeNameButtonClick);
            musicVolumeSlider.OnSliderValueChange += OnMusicVolumeValueChange;
            sfxVolumeSlider.OnSliderValueChange += OnSFXVolumeValueChange;
            musicVolumeSlider.Init(0f,1f,settingsData.MusicVolume);
            sfxVolumeSlider.Init(0f,1f,settingsData.SfxVolume);
        }

        public override void Hide()
        {
            base.Hide();
            backToMenuButton.onClick.RemoveListener(OnBackToMenuButtonClick);
            backToGameplayButton.onClick.RemoveListener(OnBackToGameplayButtonClick);
            changeNameButton.onClick.RemoveListener(OnChangeNameButtonClick);
            musicVolumeSlider.OnSliderValueChange -= OnMusicVolumeValueChange;
            sfxVolumeSlider.OnSliderValueChange -= OnSFXVolumeValueChange;
        }
    }
}