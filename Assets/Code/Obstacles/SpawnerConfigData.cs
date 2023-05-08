using System.Collections.Generic;
using UnityEngine;

namespace Code.Obstacles
{
    public class SpawnerConfigData
    {
        public SpawnerConfigData(
            List<MovableController> standardObstacles, List<MovableController> specialObstacles,
            List<MovableController> platforms, float objectsSpeed,
            Vector2 standardSpawnRange, Vector2 specialSpawnRange, Vector2 platformsSpawnRange)
        {
            StandardObstacles = standardObstacles;
            SpecialObstacles = specialObstacles;
            Platforms = platforms;
            ObjectsSpeed = objectsSpeed;
            StandardSpawnRange = standardSpawnRange;
            SpecialSpawnRange = specialSpawnRange;
            PlatformsSpawnRange = platformsSpawnRange;
        }
        
        public List<MovableController> StandardObstacles { get; }
        public List<MovableController> SpecialObstacles { get; }
        public List<MovableController> Platforms { get; }
        public float ObjectsSpeed { get; }
        public Vector2 StandardSpawnRange { get; }
        public Vector2 SpecialSpawnRange { get; }
        public Vector2 PlatformsSpawnRange { get; }
    }
}