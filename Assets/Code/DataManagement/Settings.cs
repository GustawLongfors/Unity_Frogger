using System;
using UnityEngine;

namespace Code.DataManagement
{
    [Serializable]
    public class Settings : ISaveData
    {
        [SerializeField] private float musicVolume = 0.8f;
        [SerializeField] private float sfxVolume = 0.8f;

        public event Action<float> OnMusicVolumeChanged;
        public event Action<float> OnSfxVolumeChanged;
        
        public static readonly string DefaultUniqueID = "Settings";
        public string UniqueID { get; set; } = DefaultUniqueID;

        public float MusicVolume
        {
            get => musicVolume;
            set
            {
                musicVolume = value;
                OnMusicVolumeChanged?.Invoke(value);
            }
        }
        public float SfxVolume
        {
            get => sfxVolume;
            set
            {
                sfxVolume = value;
                OnSfxVolumeChanged?.Invoke(value);
            }
        }
    }
}