using System;
using Code.DataManagement;
using Code.Levels;
using Code.Player;
using Code.Scenes;
using UnityEngine;

namespace Code.GameControl
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FinishTrigger finishTrigger;

        private PlayerController player;
        private LevelsController levelsController;
        private ScenesManager scenesManager;
        
        public static event Action OnLevelFinished;
        public static event Action OnLevelStart;
        public static event Action OnGameLost;
        
        private void Start()
        {
            SaveLoadManager.Load();
            FindReferences();
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void FindReferences()
        {
            player = FindObjectOfType<PlayerController>();
            levelsController = FindObjectOfType<LevelsController>();
            scenesManager = FindObjectOfType<ScenesManager>();
        }

        private void Player_OnHit()
        {
            OnGameLost?.Invoke();
        }

        private void FinishTrigger_OnPlayerHit()
        {
            OnLevelFinished?.Invoke();
        }

        private void LevelsController_OnLevelStart()
        {
            OnLevelStart?.Invoke();
        }

        private void LevelsController_OnLastLevelFinished()
        {
            SaveLoadManager.Save();
            scenesManager.Load(SceneNames.END_GAME);
        }

        private void SubscribeEvents()
        {
            levelsController.OnLastLevelFinished += LevelsController_OnLastLevelFinished;
            levelsController.OnLevelStart += LevelsController_OnLevelStart;
            finishTrigger.OnPlayerHit += FinishTrigger_OnPlayerHit;
            player.HitEventComponent.OnHit += Player_OnHit;
        }

        private void UnsubscribeEvents()
        {
            levelsController.OnLastLevelFinished -= LevelsController_OnLastLevelFinished;
            levelsController.OnLevelStart -= LevelsController_OnLevelStart;
            finishTrigger.OnPlayerHit -= FinishTrigger_OnPlayerHit;
            player.HitEventComponent.OnHit -= Player_OnHit;
        }
    }
}