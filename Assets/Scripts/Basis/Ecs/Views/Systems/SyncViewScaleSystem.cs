using Basis.Ecs.Views.Components;
using Basis.Views;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Views.Systems
{
    public sealed class SyncViewScaleSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _scaleFilter;
        private EcsPool<Scale> _scalePool;
        private EcsPool<ScaleSmooth> _scaleSmoothPool;

        public SyncViewScaleSystem(IEngineApi engineApi, IViewsProvider viewsProvider)
        {
            _viewsProvider = viewsProvider;
            _engineApi = engineApi;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _scaleFilter = _world
                .Filter<Scale>()
                .Inc<ActiveTag>()
                .Exc<AnimationTag>()
                .End();
            
            _scalePool = _world.GetPool<Scale>();
            _scaleSmoothPool = _world.GetPool<ScaleSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var e in _scaleFilter)
            {
                if (!_viewsProvider.TryGet<IViewObject>(e, out var view))
                {
                    continue;
                }

                var scale = _scalePool.Get(e);
                
                if (!_scaleSmoothPool.Has(e))
                {
                    view.LocalScale = scale.Value;
                }
                else
                {
                    var delta = _engineApi.DeltaTime * _scaleSmoothPool.Get(e).Value;
                    view.LocalScale = Vector3.Lerp(view.LocalScale, scale.Value, delta);
                }
            }
        }
    }
}