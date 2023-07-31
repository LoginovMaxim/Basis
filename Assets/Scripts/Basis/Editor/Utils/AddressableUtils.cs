using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Basis.Editor.Utils
{
    public static class AddressableUtils
    {
        [MenuItem("Basis/Open addressables bundles folder")]
        public static void OpenSavesFolder()
        {
            var path = Path.GetFullPath(
                Path.Combine(
                    Application.dataPath, 
                    @"..\", 
                    "Library/com.unity.addressables/aa/Android/Android"));
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                Debug.LogError("Folder does not exists!");
                return;
            }

            Process.Start(directory.FullName);
        }
    }
}