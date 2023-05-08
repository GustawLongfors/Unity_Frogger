using System;
using System.Collections;
using System.Collections.Generic;
using Code.Levels;
using Code.Pause;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Obstacles
{
    public class MovableSpawner : MonoBehaviour, IPausable
    {
        [SerializeField] private ObstacleDirection direction;
        [SerializeField] private Vector2 startCooldownRange;
        [SerializeField] private int id;

        private bool active;
        private LevelsController levelsController;
        private SpawnerConfigData spawnerConfigData;
        private readonly List<MovableController> allSpawnedObjects = new();

        private void Awake()
        {
            levelsController = FindObjectOfType<LevelsController>();
            levelsController.OnLevelLoaded += LevelController_OnLevelLoaded;
            PauseManager.RegisterPausable(this);
        }

        private void OnDestroy()
        {
            levelsController.OnLevelLoaded -= LevelController_OnLevelLoaded;
            PauseManager.UnregisterPausable(this);
        }

        private void Spawn()
        {
            if (!active) return;
            StartCoroutine(SpawnObstacleType(spawnerConfigData.StandardObstacles, spawnerConfigData.StandardSpawnRange));
            StartCoroutine(SpawnObstacleType(spawnerConfigData.SpecialObstacles, spawnerConfigData.SpecialSpawnRange));
            StartCoroutine(SpawnObstacleType(spawnerConfigData.Platforms, spawnerConfigData.PlatformsSpawnRange));
        }

        private void StopSpawning()
        {
            StopAllCoroutines();
        }

        private IEnumerator SpawnObstacleType(List<MovableController> obstacleList, Vector2 spawnRange)
        {
            if(obstacleList.Count <= 0) yield break;
            while (true)
            {
                yield return new WaitForSeconds(RandomCooldown(spawnRange));
                MovableController movableController = Instantiate(GetRandomMovable(obstacleList), transform.position,
                    Quaternion.identity);
                movableController.Init(direction,spawnerConfigData.ObjectsSpeed);
                allSpawnedObjects.Add(movableController);
            }
        }

        private float RandomCooldown(Vector2 range)
        {
            return Random.Range(range.x, range.y);
        }

        private MovableController GetRandomMovable(List<MovableController> obstacleList)
        {
            return obstacleList[Random.Range(0, obstacleList.Count)];
        }

        private void LevelController_OnLevelLoaded(int currentLevel, LevelData currentLevelData)
        {
            StopSpawning();
            allSpawnedObjects.ForEach(o =>
            {
                if(o!= null) Destroy(o.gameObject);
            });
            allSpawnedObjects.Clear();
            
            active = currentLevelData.SpawnersIds.Contains(id);
            if (!active) return;
            
            spawnerConfigData = new SpawnerConfigData(
                new List<MovableController>(currentLevelData.StandardObstacles),
                new List<MovableController>(currentLevelData.SpecialObstacles),
                new List<MovableController>(currentLevelData.Platforms),
                currentLevelData.ObjectsSpeed,
                currentLevelData.StandardSpawnRange,
                currentLevelData.SpecialSpawnRange,
                currentLevelData.PlatformsSpawnRange);
            Spawn();
        }

        public void SetPause(bool paused)
        {
            if(paused) StopSpawning();
            else Spawn();
        }
    }
}