using System.Collections.Generic;
using Code.Obstacles;
using UnityEngine;

namespace Code.Levels
{
    [CreateAssetMenu(menuName = "Data/Level Data", fileName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private GameObject levelPrefab;
        [SerializeField] private float objectsSpeed;
        [SerializeField] private List<MovableController> standardObstacles;
        [SerializeField] private List<MovableController> specialObstacles;
        [SerializeField] private List<MovableController> platforms;
        [SerializeField] private Vector2 standardSpawnRange;
        [SerializeField] private Vector2 specialSpawnRange;
        [SerializeField] private Vector2 platformsSpawnRange;
        [SerializeField] private List<int> spawnersIds;
        [SerializeField] private AudioClip levelAmbienceClip;
        
        
        public GameObject LevelPrefab => levelPrefab;
        public float ObjectsSpeed => objectsSpeed;
        public List<MovableController> StandardObstacles => standardObstacles;
        public List<MovableController> SpecialObstacles => specialObstacles;
        public List<MovableController> Platforms => platforms;
        public Vector2 StandardSpawnRange => standardSpawnRange;
        public Vector2 SpecialSpawnRange => specialSpawnRange;
        public Vector2 PlatformsSpawnRange => platformsSpawnRange;
        public List<int> SpawnersIds => spawnersIds;
        public AudioClip LevelAmbienceClip => levelAmbienceClip;
    }
}