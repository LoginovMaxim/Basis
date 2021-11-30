using System;
using System.IO;
using UnityEngine;
using Zenject;

namespace Data
{
    public class DataStorage<T> : IInitializable, IDisposable where T : IData
    {
        public T Data => _data;
        
        private T _data;
        
        public void Initialize()
        {
            Load();
            _data.DataChanged += Save;
        }
        
        private void Load()
        {
            if (typeof(T).IsInterface)
                throw new InvalidCastException("You must define T like concrete class");
            
            var dataPath = Path.Combine(Application.persistentDataPath, typeof(T) + ".json");
            _data = LoadObject<T>(dataPath) ?? (T) Activator.CreateInstance(typeof(T));
        }

        private void Save()
        {
            var dataPath = Path.Combine(Application.persistentDataPath, typeof(T) + ".json");
            SaveObject(_data, dataPath);
        }
        
        private void SaveObject(T data, string saveFilePath)
        {
            if (ContainsFile(saveFilePath))
                File.Delete(saveFilePath);
            
            File.WriteAllText(saveFilePath, JsonUtility.ToJson(data));
        }
        
        private T LoadObject<T>(string loadFilePath)
        {
            var obj = default(T);
            
            if (ContainsFile(loadFilePath))
                obj = JsonUtility.FromJson<T>(GetTextFromFile(loadFilePath));

            return obj;
        }

        private bool ContainsFile(string path) => File.Exists(path);

        private string GetTextFromFile(string path) => File.ReadAllText(path);

        public void Dispose()
        {
            _data.DataChanged -= Save;
        }
    }
}