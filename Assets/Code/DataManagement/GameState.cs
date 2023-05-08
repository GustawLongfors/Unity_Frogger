using System;

namespace Code.DataManagement
{
    [Serializable]
    public class GameState : ISaveData
    {
        public static readonly string DefaultUniqueID = "GameState";
        public string UniqueID { get; set; } = DefaultUniqueID;
        public int CurrentLevelIndex;
    }
}