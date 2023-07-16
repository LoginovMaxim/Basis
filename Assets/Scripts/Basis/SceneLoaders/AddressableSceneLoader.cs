using System;
using System.Collections.Generic;
using System.Threading;
using Basis.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Basis.SceneLoaders
{
    public sealed class AddressableSceneLoader : IAddressableSceneLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle<SceneInstance>> _activeSceneInstancesByAddressableKeys = 
            new Dictionary<string, AsyncOperationHandle<SceneInstance>>();

        public async UniTask<AsyncOperationHandle<SceneInstance>> LoadSceneAsync(
            string sceneKey, 
            LoadSceneMode loadSceneMode, 
            bool isActiveScene, 
            bool autoUnload)
        {
            if (loadSceneMode == LoadSceneMode.Single)
            {
                await UnloadAllActiveScenes();
            }
            
            var asyncOperationHandle = Addressables.LoadSceneAsync(sceneKey, loadSceneMode, isActiveScene);
            await asyncOperationHandle.Task;
            if (asyncOperationHandle.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Load scene {sceneKey} like addressable was failed");
            }
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableSceneLoader)}] Scene {sceneKey} loaded successfully".WithColor(LoggerColor.Lemon));
#endif
            
            if (autoUnload)
            {
                _activeSceneInstancesByAddressableKeys.Add(sceneKey, asyncOperationHandle);
            }
            
            return asyncOperationHandle;
        }

        public async UniTask UnloadSceneAsync(string sceneKey)
        {
            if (!_activeSceneInstancesByAddressableKeys.TryGetValue(sceneKey, out var asyncOperationHandle))
            {
                return;
            }
            
            var unloadAsyncOperationHandle = Addressables.UnloadSceneAsync(asyncOperationHandle);
            await unloadAsyncOperationHandle.Task;
            if (asyncOperationHandle.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Scene {sceneKey} unload failed");
            }
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableSceneLoader)}] Scene {sceneKey} unload successfully".WithColor(LoggerColor.Purple));
#endif

            _activeSceneInstancesByAddressableKeys.Remove(sceneKey);
        }

        public async UniTask UnloadSceneAsync(AsyncOperationHandle<SceneInstance> asyncOperationHandle)
        {
            var sceneName = asyncOperationHandle.Result.Scene.name;
            
            var unloadAsyncOperationHandle = Addressables.UnloadSceneAsync(asyncOperationHandle);
            await unloadAsyncOperationHandle.Task;
            if (asyncOperationHandle.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Scene {sceneName} unload failed");
            }
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableSceneLoader)}] Scene {sceneName} unload successfully".WithColor(LoggerColor.Purple));
#endif
        }

        private async UniTask UnloadAllActiveScenes()
        {
            var unloadSceneKeys = new List<string>(_activeSceneInstancesByAddressableKeys.Keys);
            unloadSceneKeys.Reverse();

            foreach (var unloadedSceneKey in unloadSceneKeys)
            {
                await UnloadSceneAsync(unloadedSceneKey);
            }
        }
    }
}