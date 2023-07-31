using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Basis.Data;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Basis.Editor.Utils
{
    public static class SaveTools
    {
        [MenuItem("Basis/Clear save")]
        public static void ClearSave()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IStorageItem).IsAssignableFrom(p));

            foreach (var type in types)
            {
                var storageFilePath = Path.GetFullPath(
                    Path.Combine(Application.persistentDataPath, type + ".json"));
                File.Delete(storageFilePath);
            }
        }
        
        [MenuItem("Basis/Open saves folder")]
        public static void OpenSavesFolder()
        {
            var directory = new DirectoryInfo(Application.persistentDataPath);
            if (!directory.Exists)
            {
                Debug.LogError("Folder does not exists!");
                return;
            }

            Process.Start(directory.FullName);
        }
    }
}