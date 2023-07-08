using System;
using Basis.App.Views;
using Zenject;

namespace Basis.App.Pool
{
    public abstract class ViewPool<TViewObject> : MemoryPool<TViewObject>, IViewPool where TViewObject : IViewObject
    {
        private IPoolService _poolService;
        protected abstract Type _viewObjectType { get; }

        [Inject]
        public void Inject(IPoolService poolService)
        {
            _poolService = poolService;
        }

        protected override void OnCreated(TViewObject item)
        {
            item.OnReinitialized();
        }

        protected override void Reinitialize(TViewObject item)
        {
            item.OnReinitialized();
        }

        protected override void OnDespawned(TViewObject item)
        {
            item.OnDespawned();
        }

        public override void Dispose()
        {
            _poolService.TryRemoveViewPool(_viewObjectType);
        }

        IViewObject IViewPool.Spawn()
        {
            return Spawn();
        }

        void IViewPool.Despawn(IViewObject viewObject)
        {
            Despawn((TViewObject) viewObject);
        }
    }
}