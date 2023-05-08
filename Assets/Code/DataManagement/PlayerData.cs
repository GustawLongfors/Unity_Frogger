using System;

namespace Code.DataManagement
{
    [Serializable]
    public class PlayerData : ISaveData
    {
        public static readonly string DefaultUniqueID = "PlayerData";
        public string UniqueID { get; set; } = DefaultUniqueID;
        public string Name;
    }
}