using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Basis.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Basis.ResourceProviders
{
    public sealed class AddressableResourceProvider : IResourceProvider, IDisposable
    {
        private Dictionary<string, Object> _cachedObjectsByKeys = new Dictionary<string, Object>();
        private Dictionary<string, GameObject> _cachedGameObjectsByKeys = new Dictionary<string, GameObject>();

        public async UniTask<TObject> LoadResourceAsync<TObject>(string key, CancellationToken token) where TObject : Object
        {
            lock (_cachedObjectsByKeys)
            {
                if (_cachedObjectsByKeys.TryGetValue(key, out var cachedObject))
                {
                    return (TObject)cachedObject;
                }
            }

            lock (_cachedGameObjectsByKeys)
            {
                if (_cachedGameObjectsByKeys.TryGetValue(key, out var cachedGameObject) && 
                    cachedGameObject.TryGetComponent<TObject>(out var cachedComponent))
                {
                    return cachedComponent;
                }
            }

            return await LoadResourceAsync<TObject>(key);
        }

        public void UnloadResource(string resourceId)
        {
            lock (_cachedObjectsByKeys)
            {
                if (_cachedObjectsByKeys.TryGetValue(resourceId, out var resource))
                {
                    UnloadAddressableResource(resourceId, resource);
                    return;
                }
            }

            lock (_cachedGameObjectsByKeys)
            {
                if (_cachedGameObjectsByKeys.TryGetValue(resourceId, out var gameObjectResource))
                {
                    UnloadGameObjectAddressableResource(resourceId, gameObjectResource);
                    return;
                }
            }

#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] Missing asset with key '{resourceId}' in cache for release"
                .WithColor(LoggerColor.Red));
#endif
        }

        private async UniTask<TObject> LoadResourceAsync<TObject>(string key) where TObject : Object
        {
            if (typeof(TObject).IsSubclassOf(typeof(Component)) || typeof(TObject).IsSubclassOf(typeof(GameObject)))
            {
                return await LoadGameObjectAddressableResource<TObject>(key);
            }
            
            return await LoadAddressableResource<TObject>(key);
        }

        private void UnloadAddressableResource(string resourceId, Object resource)
        {
            Addressables.Release(resource);
            _cachedObjectsByKeys.Remove(resourceId);

#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] Asset with key '{resourceId}' was release requested"
                .WithColor(LoggerColor.Purple));
#endif
        }

        private void UnloadGameObjectAddressableResource(string resourceId, GameObject gameObjectResource)
        {
            Addressables.Release(gameObjectResource);
            _cachedGameObjectsByKeys.Remove(resourceId);

#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] Asset with key '{resourceId}' was release requested as GameObject"
                .WithColor(LoggerColor.Purple));
#endif
        }

        private async UniTask<TObject> LoadAddressableResource<TObject>(string key) where TObject : Object
        {
            var asyncOperationHandler = Addressables.LoadAssetAsync<TObject>(key);
            await asyncOperationHandler.Task;
            if (asyncOperationHandler.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Failed to load addressable asset with key {key}");
            }

#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] asset with key {key} was loaded".WithColor(Color.cyan));
#endif

            lock (_cachedObjectsByKeys)
            {
                if (_cachedObjectsByKeys.TryGetValue(key, out var result))
                {
                    Addressables.Release(asyncOperationHandler.Result);
                    return (TObject) result;
                }
                
                _cachedObjectsByKeys.Add(key, asyncOperationHandler.Result);
            }
            
            return asyncOperationHandler.Result;
        }

        private async UniTask<TObject> LoadGameObjectAddressableResource<TObject>(string key)
        {
            var asyncOperationHandler = Addressables.LoadAssetAsync<GameObject>(key);
            await asyncOperationHandler.Task;
            if (asyncOperationHandler.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Failed to load addressable asset with key {key}");
            }

            if (!asyncOperationHandler.Result.TryGetComponent<TObject>(out var prefab))
            {
                throw new Exception($"Loaded asset with {key} key hasn't a component {typeof(TObject)}");
            }

#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] asset with key {key} was loaded like gameObject prefab".WithColor(Color.cyan));
#endif

            lock (_cachedGameObjectsByKeys)
            {
                if (_cachedGameObjectsByKeys.ContainsKey(key))
                {
                    Addressables.Release(asyncOperationHandler.Result);
                    return prefab;
                }
                
                _cachedGameObjectsByKeys.Add(key, asyncOperationHandler.Result);
            }
            
            return prefab;
        }

        public void Dispose()
        {
            lock (_cachedObjectsByKeys)
            {
                var removeCacheObjectKeys = new List<string>(_cachedObjectsByKeys.Keys);
                foreach (var removeCacheObjectKey in removeCacheObjectKeys)
                {
                    UnloadResource(removeCacheObjectKey);
                }
            }

            lock (_cachedGameObjectsByKeys)
            {
                var removeCacheGameObjectKeys = new List<string>(_cachedGameObjectsByKeys.Keys);
                foreach (var removeCacheGameObjectKey in removeCacheGameObjectKeys)
                {
                    UnloadResource(removeCacheGameObjectKey);
                }
            }
        }
    }
}