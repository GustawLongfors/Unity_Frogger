using UnityEngine;

namespace Code.Audio
{
    public class AudioPlayer : IAudioPlayer
    {
        private readonly AudioSource musicSource;
        private readonly AudioSource ambienceSource;
        private readonly AudioSource sfxSource;
        
        public AudioPlayer(AudioSource musicSource, AudioSource ambienceSource, AudioSource sfxSource)
        {
            this.musicSource = musicSource;
            this.ambienceSource = ambienceSource;
            this.sfxSource = sfxSource;
        }
        
        public void PlaySFX(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.Stop();
            musicSource.loop = true;
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void PlayAmbience(AudioClip clip)
        {
            ambienceSource.Stop();
            ambienceSource.loop = true;
            ambienceSource.clip = clip;
            ambienceSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void StopAmbience()
        {
            ambienceSource.Stop();
        }
    }
}