using System;
using System.IO;
using UnityEngine;

namespace Code.DataManagement
{
    public static class SaveLoadManager
    {
        private static readonly JsonSerializer JsonSerializer = new();
        private static readonly string SaveFolder = $"{Application.persistentDataPath}/Saves/";

        private static event Action OnSave;
        private static event Action OnLoad;

        public static void SaveData<T>(T dataToSave) where T : ISaveData
        {
            string jsonString = JsonSerializer.SerializeToJson(dataToSave);
            string filePath = GetFilePath(dataToSave.UniqueID, JsonSerializer.FileExtension);
            File.WriteAllText(filePath, jsonString);
        }

        public static T LoadData<T>(string uniqueID) where T : ISaveData, new()
        {
            string filePath = GetFilePath(uniqueID, JsonSerializer.FileExtension);
            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"Save file not found: {filePath}");
                return new T();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.DeserializeFromJson<T>(jsonString);
        }
        
        public static void Save()
        {
            OnSave?.Invoke();
        }

        public static void Load()
        {
            OnLoad?.Invoke();
        }

        private static string GetFilePath(string uniqueID, string fileExtension)
        {
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }

            return $"{SaveFolder}{uniqueID}.{fileExtension}";
        }

        #region Savable Loadable Registration

        public static void RegisterSavable(ISavable savableObject)
        {
            OnSave += savableObject.SaveData;
        }

        public static void RegisterLoadable(ILoadable loadableObject)
        {
            OnLoad += loadableObject.LoadData;
        }

        public static void UnregisterSavable(ISavable savableObject)
        {
            OnSave -= savableObject.SaveData;
        }
        
        public static void UnregisterLoadable(ILoadable loadableObject)
        {
            OnLoad -= loadableObject.LoadData;
        }

        #endregion Savable Loadable Registration
    }
}