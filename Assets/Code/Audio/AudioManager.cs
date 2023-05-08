using Code.Common;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Audio
{
    public class AudioManager : InstantiatableSingleton<AudioManager>, IInstantiatableSingleton
    {
        private AudioMixerGroup musicMixerGroup;
        private AudioMixerGroup sfxMixerGroup;
        private AudioMixer mainMixer;
        private AudioSource musicSource;
        private AudioSource ambienceSource;
        private AudioSource sfxSource;

        public IAudioPlayer Player { get; private set; }
        public IVolumeControl VolumeControl { get; private set; }

        private const string AUDIO_MIXER_NAME = "MainMixer";
        private const string MUSIC_MIXER_GROUP = "Music";
        private const string SFX_MIXER_GROUP = "SFX";
        private const string MUSIC_SOURCE_NAME = "Music Source";
        private const string AMBIENCE_SOURCE_NAME = "Ambience Source";
        private const string SFX_SOURCE_NAME = "SFX Source";

        private void LoadMixer()
        {
            mainMixer = Resources.Load<AudioMixer>(AUDIO_MIXER_NAME);
        }

        private void LoadGroups()
        {
            musicMixerGroup = mainMixer.FindMatchingGroups(MUSIC_MIXER_GROUP)[0];
            sfxMixerGroup = mainMixer.FindMatchingGroups(SFX_MIXER_GROUP)[0];
        }
        
        private void CreateSources()
        {
            musicSource = CreateAudioSource(MUSIC_SOURCE_NAME, musicMixerGroup);
            ambienceSource = CreateAudioSource(AMBIENCE_SOURCE_NAME, sfxMixerGroup);
            sfxSource = CreateAudioSource(SFX_SOURCE_NAME, sfxMixerGroup);
        }

        private void CreatePlayer()
        {
            Player = new AudioPlayer(musicSource, ambienceSource, sfxSource);
        }

        private void CreateVolumeControl()
        {
            VolumeControl = new VolumeControl(mainMixer);
        }
        
        private AudioSource CreateAudioSource(string sourceName, AudioMixerGroup mixerGroup)
        {
            GameObject sourceObject = new GameObject(sourceName);
            sourceObject.transform.SetParent(transform);
            AudioSource source = sourceObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = mixerGroup;
            return source;
        }

        public void OnInstanceCreated()
        {
            LoadMixer();
            LoadGroups();
            CreateSources();
            CreatePlayer();
            CreateVolumeControl();
        }
    }
}
