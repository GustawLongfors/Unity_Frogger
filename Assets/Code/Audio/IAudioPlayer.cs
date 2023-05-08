using UnityEngine;

namespace Code.Audio
{
    public interface IAudioPlayer
    {
        void PlaySFX(AudioClip clip);
        void PlayMusic(AudioClip clip);
        void PlayAmbience(AudioClip clip);
        void StopMusic();
        void StopAmbience();
    }
}