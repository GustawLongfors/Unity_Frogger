using UnityEngine;
using UnityEngine.Audio;

namespace Code.Audio
{
    public class VolumeControl : IVolumeControl
    {
        private readonly AudioMixer mainMixer;
        private const string MUSIC_VOLUME = "MusicVolume";
        private const string SFX_VOLUME = "SFXVolume";

        public VolumeControl(AudioMixer mainMixer)
        {
            this.mainMixer = mainMixer;
        }
        
        public void SetMusicVolume(float volume)
        {
            mainMixer.SetFloat(MUSIC_VOLUME, GetDecibel(volume));
        }

        public void SetSFXVolume(float volume)
        {
            mainMixer.SetFloat(SFX_VOLUME, GetDecibel(volume));
        }

        private float GetDecibel(float value)
        {
            float offset = 0.00001f;
            return 20f * Mathf.Log10(value + offset);
        }
    }
}