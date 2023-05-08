using System.Collections.Generic;
using UnityEngine;

namespace Code.Levels
{
    [CreateAssetMenu(fileName = "LevelDataContainer", menuName = "Data/Level Data Container")]
    public class LevelDataContainer : ScriptableObject
    {
        [SerializeField] private List<LevelData> levels;

        public LevelData GetLevel(int index) => levels[index];
        public int LevelsCount => levels.Count;
    }
}