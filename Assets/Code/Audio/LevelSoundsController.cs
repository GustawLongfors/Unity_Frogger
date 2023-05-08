using Code.Levels;
using UnityEngine;

namespace Code.Audio
{
    public class LevelSoundsController : MonoBehaviour
    {
        [SerializeField] private SoundsDatabase soundsDatabase;

        private LevelsController levelsController;
        private void Awake()
        {
            SetupLevelsController();
            PlayMusic();
        }

        private void OnDestroy()
        {
            AudioManager.Instance.Player.StopAmbience();
            if (levelsController == null) return;
            levelsController.OnLevelLoaded -= LevelsController_OnLevelLoaded;
        }

        private void SetupLevelsController()
        {
            levelsController = FindObjectOfType<LevelsController>();
            if (levelsController == null) return;
            levelsController.OnLevelLoaded += LevelsController_OnLevelLoaded;
        }

        private void LevelsController_OnLevelLoaded(int levelIndex, LevelData levelData)
        {
            if (levelData.LevelAmbienceClip == null) return;
            AudioManager.Instance.Player.PlayAmbience(levelData.LevelAmbienceClip);
        }

        private void PlayMusic()
        {
            AudioManager.Instance.Player.PlayMusic(soundsDatabase.MusicClip);
        }
    }
}