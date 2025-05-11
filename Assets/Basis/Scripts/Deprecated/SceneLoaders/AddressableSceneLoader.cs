using System;
using System.Collections.Generic;
using System.Threading;
using BasisCore.Extensions;
using BasisCore.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Basis.Deprecated.SceneLoaders
{
    public sealed class AddressableSceneLoader : ISceneLoader
    {
        private readonly List<KeyValuePair<string, SceneInstance>> _activeSceneInstancesByKeys;
        private readonly List<string> _currentLoadingSceneKeys;
        private readonly List<string> _currentUnloadingSceneKeys;

        public AddressableSceneLoader()
        {
            _activeSceneInstancesByKeys = new List<KeyValuePair<string, SceneInstance>>();
            _currentLoadingSceneKeys = new List<string>();
            _currentUnloadingSceneKeys = new List<string>();
        }

        public async UniTask LoadSceneAsync(string sceneKey, LoadSceneMode loadSceneMode, bool isActiveScene, CancellationToken token)
        {
            if (TryGetSceneInstanceByKey(sceneKey, out _))
            {
#if DEBUG
                Debug.Log($"[{nameof(AddressableSceneLoader)}] The scene {sceneKey} is already loaded."
                    .WithColor(LoggerColor.Red));
#endif
                return;
            }

            lock (_currentLoadingSceneKeys)
            {
                if (_currentLoadingSceneKeys.Contains(sceneKey))
                {
#if DEBUG
                    Debug.Log($"[{nameof(AddressableSceneLoader)}] You cannot load a scene {sceneKey} " +
                              $"that is already loading at the moment".WithColor(LoggerColor.Red));
#endif
                    return;
                }
            
                _currentLoadingSceneKeys.Add(sceneKey);
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
            
            lock (_activeSceneInstancesByKeys)
            {
                _activeSceneInstancesByKeys.Add(
                    new KeyValuePair<string, SceneInstance>(sceneKey, asyncOperationHandle.Result));
            }

            lock (_currentLoadingSceneKeys)
            {
                _currentLoadingSceneKeys.Remove(sceneKey);
            }
        }

        public async UniTask UnloadSceneAsync(string sceneKey, CancellationToken token)
        {
            if (!TryGetSceneInstanceByKey(sceneKey, out var sceneInstanceByKey))
            {
                throw new Exception($"Can't unload the scene {sceneKey}. The scene has not loaded before.");
            }
            
            lock (_currentUnloadingSceneKeys)
            {
                if (_currentUnloadingSceneKeys.Contains(sceneKey))
                {
#if DEBUG
                    Debug.Log($"[{nameof(AddressableSceneLoader)}] You cannot unload a scene {sceneKey} " +
                              $"that is already unloading at the moment".WithColor(LoggerColor.Red));
#endif
                    return;
                }

                _currentUnloadingSceneKeys.Add(sceneKey);
            }
            
            var unloadAsyncOperationHandle = Addressables.UnloadSceneAsync(sceneInstanceByKey.Value);
            await unloadAsyncOperationHandle.Task;
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableSceneLoader)}] Scene {sceneKey} unload successfully".WithColor(LoggerColor.Purple));
#endif

            lock (_activeSceneInstancesByKeys)
            {
                _activeSceneInstancesByKeys.Remove(sceneInstanceByKey);
            }

            lock (_currentUnloadingSceneKeys)
            {
                _currentUnloadingSceneKeys.Remove(sceneKey);
            }
        }

        private bool TryGetSceneInstanceByKey(string sceneKey, out KeyValuePair<string, SceneInstance> sceneInstanceByKey)
        {
            lock (_activeSceneInstancesByKeys)
            {
                foreach (var activeSceneInstancesByAddressableKey in _activeSceneInstancesByKeys)
                {
                    if (activeSceneInstancesByAddressableKey.Key != sceneKey)
                    {
                        continue;
                    }

                    sceneInstanceByKey = activeSceneInstancesByAddressableKey;
                    return true;
                } 
            }

            sceneInstanceByKey = default;
            return false;
        }
    }
}