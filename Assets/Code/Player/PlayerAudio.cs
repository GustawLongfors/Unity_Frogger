using Code.Audio;

namespace Code.Player
{
    public class PlayerAudio
    {
        private readonly IAudioPlayer player;
        private readonly SoundsDatabase soundsDatabase;

        public PlayerAudio(IAudioPlayer player, SoundsDatabase soundsDatabase)
        {
            this.player = player;
            this.soundsDatabase = soundsDatabase;
        }

        public void PlayJumpSound()
        {
            player.PlaySFX(soundsDatabase.JumpClip);
        }

        public void PlayHitSound()
        {
            player.PlaySFX(soundsDatabase.HitClip);
        }
    }
}