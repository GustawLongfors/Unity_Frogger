using UnityEngine;

namespace Code.DataManagement
{
    public class JsonSerializer
    {
        public string FileExtension => "json";

        public string SerializeToJson<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }

        public T DeserializeFromJson<T>(string jsonString)
        {
            return JsonUtility.FromJson<T>(jsonString);
        }
    }
}