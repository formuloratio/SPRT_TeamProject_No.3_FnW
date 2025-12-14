using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Core
{
    public class DataService
    {

        private const string SaveFileExtension = ".json";
        private readonly string _prefix;

        public DataService(string prefix)
        {
            _prefix = prefix;
        }

        public bool Save<T>(T data, string fileName)
        {
            string fullFileName = GetFullFileName(fileName);
            return JsonSerializer.SaveToJson(data, fullFileName);
        }

        public T Load<T>(string fileName) where T : new()
        {
            string fullFileName = GetFullFileName(fileName);
            return JsonSerializer.LoadFromJson<T>(fullFileName);
        }

        public Dictionary<string, T> LoadAll<T>(List<string> fileNames) where T : new()
        {
            Dictionary<string, T> loadedData = new Dictionary<string, T>();

            foreach (string fileName in fileNames)
            {
                string fullFileName = GetFullFileName(fileName);

                if (JsonSerializer.FileExists(fullFileName))
                {
                    T data = JsonSerializer.LoadFromJson<T>(fullFileName);
                    loadedData[fileName] = data;
                }
            }
            return loadedData;
        }

        private string GetFullFileName(string fileName)
        {
            string fullName = string.IsNullOrEmpty(_prefix)
                ? fileName
                : $"{_prefix}_{fileName}";
            if (!fileName.EndsWith(SaveFileExtension))
            {
                return fullName += SaveFileExtension;
            }
            return fullName;
        }
    }
}