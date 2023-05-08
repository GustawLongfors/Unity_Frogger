using Code.Audio;
using UnityEngine;

namespace Code.DataManagement
{
    public class GameSettingsManager : MonoBehaviour, ILoadable, ISavable
    {
        public Settings SettingsData { get; private set; }
        public PlayerData PlayerData { get; private set; }

        private void Awake()
        {
            SaveLoadManager.RegisterLoadable(this);
            SaveLoadManager.RegisterSavable(this);
        }

        private void OnDestroy()
        {
            SaveLoadManager.UnregisterLoadable(this);
            SaveLoadManager.UnregisterSavable(this);
            UnsubscribeAudio();
        }

        public void LoadData()
        {
            SettingsData = SaveLoadManager.LoadData<Settings>(Settings.DefaultUniqueID);
            PlayerData = SaveLoadManager.LoadData<PlayerData>(PlayerData.DefaultUniqueID);
            SubscribeAudio();
        }

        public void SaveData()
        {
            SaveLoadManager.SaveData(SettingsData);
            SaveLoadManager.SaveData(PlayerData);
        }

        private void SubscribeAudio()
        {
            SettingsData.OnMusicVolumeChanged += AudioManager.Instance.VolumeControl.SetMusicVolume;
            SettingsData.OnSfxVolumeChanged += AudioManager.Instance.VolumeControl.SetSFXVolume;
            AudioManager.Instance.VolumeControl.SetMusicVolume(SettingsData.MusicVolume);
            AudioManager.Instance.VolumeControl.SetSFXVolume(SettingsData.SfxVolume);
        }

        private void UnsubscribeAudio()
        {
            SettingsData.OnMusicVolumeChanged -= AudioManager.Instance.VolumeControl.SetMusicVolume;
            SettingsData.OnSfxVolumeChanged -= AudioManager.Instance.VolumeControl.SetSFXVolume;
        }
    }
}
