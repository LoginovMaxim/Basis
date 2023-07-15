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
    public sealed class AddressableSceneLoader : ISceneLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle<SceneInstance>> _activeSceneInstancesByAddressableKeys = 
            new Dictionary<string, AsyncOperationHandle<SceneInstance>>();

        public async UniTask LoadSceneAsync(string sceneKey, bool isActiveScene, LoadSceneMode loadSceneMode, CancellationToken token)
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
            
            _activeSceneInstancesByAddressableKeys.Add(sceneKey, asyncOperationHandle);
        }

        public async UniTask UnloadSceneAsync(string sceneKey, CancellationToken token)
        {
            if (!_activeSceneInstancesByAddressableKeys.TryGetValue(sceneKey, out var asyncOperationHandle))
            {
                return;
            }
            
            var unloadAsyncOperationHandle = Addressables.UnloadSceneAsync(asyncOperationHandle.Result);
            await unloadAsyncOperationHandle.Task;
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableSceneLoader)}] Scene {sceneKey} unload successfully".WithColor(LoggerColor.Purple));
#endif

            _activeSceneInstancesByAddressableKeys.Remove(sceneKey);
        }

        private async UniTask UnloadAllActiveScenes()
        {
            var unloadSceneKeys = new List<string>(_activeSceneInstancesByAddressableKeys.Keys);
            unloadSceneKeys.Reverse();

            foreach (var unloadedSceneKey in unloadSceneKeys)
            {
                await UnloadSceneAsync(unloadedSceneKey, new CancellationToken());
            }
        }
    }
}