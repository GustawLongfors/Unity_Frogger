using System;
using System.Collections.Generic;
using Code.Audio;
using Code.DataManagement;
using Code.GameControl;
using Code.Timers;
using UnityEngine;

namespace Code.Levels
{
    public class LevelsController : MonoBehaviour, ISavable, ILoadable
    {
        [SerializeField] private LevelDataContainer levelDataContainer;
        [SerializeField] private Vector3 spawnPosition;
        
        private int currentLevel;
        private GameObject currentLevelObject;
        private LevelData currentLevelData;
        private GameState gameStateData = new();

        public event Action<int, LevelData> OnLevelLoaded;
        public event Action OnLevelStart;
        public event Action OnLastLevelFinished;

        public ITimer Timer { get; private set; }
        public ITimer CountdownTimer { get; private set; }
        
        private void Awake()
        {
            SaveLoadManager.RegisterSavable(this);
            SaveLoadManager.RegisterLoadable(this);
            Timer = new StandardTimer(TimeSpan.FromSeconds(1));
            CountdownTimer = new CountdownTimer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));
            CountdownTimer.OnStop += CountdownTimer_OnStop;
        }

        private void OnDestroy()
        {
            SaveLoadManager.UnregisterSavable(this);
            SaveLoadManager.UnregisterLoadable(this);
            Timer.Stop();
            CountdownTimer.Stop();
        }

        private void Start()
        {
            GameManager.OnLevelFinished += GameManager_OnLevelFinished;
        }

        private void LoadNextLevel()
        {
            HandleTimers();
            DestroyCurrentLevelObject();
            currentLevelData = levelDataContainer.GetLevel(currentLevel);
            currentLevel++;
            currentLevelObject = Instantiate(currentLevelData.LevelPrefab, spawnPosition, Quaternion.identity);
            OnLevelLoaded?.Invoke(currentLevel, currentLevelData);
        }

        private void DestroyCurrentLevelObject()
        {
            if (currentLevelObject != null)
            {
                Destroy(currentLevelObject);
            }
        }

        private void GameManager_OnLevelFinished()
        {
            Timer.Stop();
            if (levelDataContainer.LevelsCount == currentLevel)
            {
                currentLevel = 1;
                OnLastLevelFinished?.Invoke();
                return;
            }
            
            LoadNextLevel();
        }

        private void HandleTimers()
        {
            CountdownTimer?.Restart();
        }

        private void CountdownTimer_OnStop()
        {
            OnLevelStart?.Invoke();
            Timer?.Restart();
        }
        
        public void SaveData()
        {
            gameStateData.CurrentLevelIndex = currentLevel - 1;
            SaveLoadManager.SaveData(gameStateData);
        }

        public void LoadData()
        {
            gameStateData = SaveLoadManager.LoadData<GameState>(gameStateData.UniqueID);
            currentLevel = gameStateData.CurrentLevelIndex;
            LoadNextLevel();
        }
    }
}