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
            if (_cachedObjectsByKeys.TryGetValue(key, out var cachedObject))
            {
                return (TObject)cachedObject;
            }

            if (_cachedGameObjectsByKeys.TryGetValue(key, out var cachedGameObject) && 
                cachedGameObject.TryGetComponent<TObject>(out var cachedComponent))
            {
                return cachedComponent;
            }
            
            return await LoadResourceAsync<TObject>(key);
        }

        public void UnloadResource<TObject>(TObject resourceObject) where TObject : Object
        {
            var resourceKey = _cachedObjectsByKeys.FirstOrDefault(c => c.Value.Equals(resourceObject)).Key;
            if (!string.IsNullOrEmpty(resourceKey))
            {
                UnloadResource(resourceKey);
                return;
            }
            
            var gameObjectResourceKey = _cachedGameObjectsByKeys.FirstOrDefault(c => c.Value.Equals(resourceObject)).Key;
            if (!string.IsNullOrEmpty(gameObjectResourceKey))
            {
                UnloadResource(gameObjectResourceKey);
                return;
            }
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] Missing asset with type '{resourceObject.GetType()}' in cache for release"
                .WithColor(LoggerColor.Red));
#endif
        }

        public void UnloadResource(string resourceId)
        {
            if (_cachedObjectsByKeys.TryGetValue(resourceId, out var resource))
            {
                UnLoadAddressableResource(resourceId, resource);
                return;
            }

            if (_cachedGameObjectsByKeys.TryGetValue(resourceId, out var gameObjectResource))
            {
                UnloadGameObjectAddressableResource(resourceId, gameObjectResource);
                return;
            }
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] Missing asset with key '{resourceId}' in cache for release"
                .WithColor(LoggerColor.Red));
#endif
        }

        private async UniTask<TObject> LoadResourceAsync<TObject>(string key) where TObject : Object
        {
            var isComponent = typeof(TObject).IsSubclassOf(typeof(Component));
            var isGameObject = typeof(TObject).IsSubclassOf(typeof(GameObject));

            if (!isComponent && !isGameObject)
            {
                return await LoadAddressableResource<TObject>(key);
            }

            return await LoadGameObjectAddressableResource<TObject>(key);
        }

        private void UnLoadAddressableResource(string resourceId, Object resource)
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
            
            _cachedObjectsByKeys.Add(key, asyncOperationHandler.Result);
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
            
            _cachedGameObjectsByKeys.Add(key, asyncOperationHandler.Result);
            return prefab;
        }

        public void Dispose()
        {
            var removeCacheKeys = new List<string>(_cachedObjectsByKeys.Keys);
            foreach (var removeCacheKey in removeCacheKeys)
            {
                UnloadResource(removeCacheKey);
            }
        }
    }
}