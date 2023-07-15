using System;
using System.Threading;
using System.Threading.Tasks;
using Basis.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Basis.ResourceProviders
{
    public sealed class AddressableResourceProvider : IResourceProvider
    {
        public async Task<TObject> LoadResourceAsync<TObject>(string key, CancellationToken token) where TObject : Object
        {
            var addressableHandle = await LoadResourceAsync<TObject>(key);
            ReleaseAsset(addressableHandle.AsyncOperationHandle);
            return addressableHandle.Object;
        }

        private async Task<AddressableHandle<TObject>> LoadResourceAsync<TObject>(string key) where TObject : Object
        {
            var isComponent = typeof(TObject).IsSubclassOf(typeof(Component));
            var isGameObject = typeof(TObject).IsSubclassOf(typeof(GameObject));

            if (!isComponent && !isGameObject)
            {
                return await LoadAddressableAsset<TObject>(key);
            }

            return await LoadGameObjectAddressableAsset<TObject>(key);
        }

        private async Task<AddressableHandle<TObject>> LoadAddressableAsset<TObject>(string key)
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
            
            return new AddressableHandle<TObject>(asyncOperationHandler, asyncOperationHandler.Result);
        }
        
        private async Task<AddressableHandle<TObject>> LoadGameObjectAddressableAsset<TObject>(string key)
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
            
            return new AddressableHandle<TObject>(asyncOperationHandler, prefab);
        }

        private void ReleaseAsset(AsyncOperationHandle asyncOperationHandle)
        {
            Addressables.Release(asyncOperationHandle);
            
#if DEBUG
            Debug.Log($"[{nameof(AddressableResourceProvider)}] asset {asyncOperationHandle.DebugName} was release requested"
                .WithColor(Color.blue));
#endif
        }
        
        private struct AddressableHandle<TObject>
        {
            public AsyncOperationHandle AsyncOperationHandle { get; }
            public TObject Object { get; }

            public AddressableHandle(AsyncOperationHandle asyncOperationHandle, TObject resultObject)
            {
                AsyncOperationHandle = asyncOperationHandle;
                Object = resultObject;
            }
        }
    }
}