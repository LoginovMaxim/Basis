using System;
using System.IO;
using UnityEngine;

namespace Basis.App.Data
{
    public sealed class DataStorage<T> : IDataStorage<T>, IDisposable where T : IStorageItem
    {
        private T _storageItem;

        public DataStorage()
        {
            Load();
            _storageItem.OnItemChanged += Save;
        }
        
        private void Load()
        {
            if (typeof(T).IsInterface)
            {
                throw new InvalidCastException("You must define T like concrete class");
            }
            
            _storageItem = LoadObject<T>() ?? (T) Activator.CreateInstance(typeof(T));
        }

        private void Save()
        {
            SaveObject(_storageItem);
        }
        
        private void SaveObject(T data)
        {
            var saveFilePath = GetStorageItemPath();
            if (ContainsFile(saveFilePath))
            {
                File.Delete(saveFilePath);
            }
            
            File.WriteAllText(saveFilePath, JsonUtility.ToJson(data));
        }
        
        private T LoadObject<T>()
        {
            var obj = default(T);

            var loadFilePath = GetStorageItemPath();
            if (ContainsFile(loadFilePath))
            {
                obj = JsonUtility.FromJson<T>(GetTextFromFile(loadFilePath));
            }

            return obj;
        }

        private string GetStorageItemPath()
        {
            return Path.Combine(Application.persistentDataPath, typeof(T) + ".json");
        }

        private bool ContainsFile(string path) => File.Exists(path);

        private string GetTextFromFile(string path) => File.ReadAllText(path);

        private void Dispose()
        {
            _storageItem.OnItemChanged -= Save;
        }

        #region IDataStorage<T>

        T IDataStorage<T>.Data => _storageItem;

        #endregion
        
        #region IDisposable

        void IDisposable.Dispose()
        {
            Dispose();
        }

        #endregion
    }
}