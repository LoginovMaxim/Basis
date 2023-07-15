using Basis.Pool;
using Basis.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.Factory
{
    public abstract class BasePoolViewFactory<TViewObject, TViewPayload> : IViewFactory<TViewObject, TViewPayload> 
        where TViewObject : IViewObject 
        where TViewPayload : IViewPayload
    {
        private readonly IPoolService _poolService;
        private readonly IViewsProvider _viewsProvider;
        
        protected abstract Transform TransformParent { get; }
        
        public void CreateView(int entityId, TViewPayload viewPayload)
        {
            UniTask.Create(() => CreateViewAsync(entityId, viewPayload));
        }

        public void ReleaseView(int entityId)
        {
            _viewsProvider.TryGet(entityId, out var view);
            if (view is not PoolObject poolObject)
            {
                return;
            }

            _poolService.Despawn(poolObject);
            _viewsProvider.TryRemove(entityId);
        }

        private async UniTask CreateViewAsync(int entityId, TViewPayload viewPayload)
        {
            var view = await _poolService.Spawn<PoolObject>(viewPayload.ResourceId);
            view.transform.parent = TransformParent;
            _viewsProvider.TryAdd(entityId, view);
        }
    }
}