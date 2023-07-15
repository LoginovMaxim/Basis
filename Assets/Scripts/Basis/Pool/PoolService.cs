using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basis.ResourceProviders;
using UnityEngine;

namespace Basis.Pool
{
    public sealed class PoolService : MonoBehaviour, IPoolService
    {
        private readonly IResourceProvider _resourceProvider;

        private readonly Dictionary<string, Stack<PoolObject>> _poolObjectsByResourceIds;

        public PoolService(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;

            _poolObjectsByResourceIds = new Dictionary<string, Stack<PoolObject>>();
        }

        public async Task<TPoolObject> Spawn<TPoolObject>(string resourceId) where TPoolObject : PoolObject
        {
            if (TryGetPoolObjectFromPoolCache(resourceId, out var cachedPoolObject))
            {
                cachedPoolObject.Reinitialize();
                return (TPoolObject) cachedPoolObject;
            }
            
            var resource = await _resourceProvider.LoadResourceAsync<TPoolObject>(resourceId, new CancellationToken());
            var poolObject = Instantiate(resource);
            
            poolObject.ResourceId = resourceId;
            poolObject.Reinitialize();
            
            return poolObject;
        }

        public void Despawn(PoolObject poolObject)
        {
            poolObject.Deactivate();
            AddPoolObjectToPoolCache(poolObject.ResourceId, poolObject);
        }

        private bool TryGetPoolObjectFromPoolCache(string resourceId, out PoolObject poolObject)
        {
            poolObject = default;
            return _poolObjectsByResourceIds.TryGetValue(resourceId, out var poolObjects) && poolObjects.TryPop(out poolObject);
        }

        private void AddPoolObjectToPoolCache(string resourceId, PoolObject poolObject)
        {
            if (_poolObjectsByResourceIds.TryGetValue(resourceId, out var poolObjects))
            {
                poolObjects.Push(poolObject);
                return;
            }

            var poolObjectsStack = new Stack<PoolObject>();
            poolObjectsStack.Push(poolObject);
            
            _poolObjectsByResourceIds.Add(resourceId, poolObjectsStack);
        }
    }
}