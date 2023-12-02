using Basis.Ecs.Views.Components;
using Basis.Views;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Views.Systems
{
    public sealed class SyncViewRotationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _rotationFilter;
        private EcsPool<Rotation> _rotationPool;
        private EcsPool<RotationSmooth> _rotationSmoothPool;

        public SyncViewRotationSystem(IEngineApi engineApi, IViewsProvider viewsProvider)
        {
            _viewsProvider = viewsProvider;
            _engineApi = engineApi;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _rotationFilter = _world
                .Filter<Rotation>()
                .Inc<ActiveTag>()
                .Exc<AnimationTag>()
                .End();
            
            _rotationPool = _world.GetPool<Rotation>();
            _rotationSmoothPool = _world.GetPool<RotationSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var e in _rotationFilter)
            {
                if (!_viewsProvider.TryGet<IViewObject>(e, out var view))
                {
                    continue;
                }
                
                var rotation = _rotationPool.Get(e);
                
                if (!_rotationSmoothPool.Has(e))
                {
                    view.Rotation = rotation.Value;
                }
                else
                {
                    var delta = _engineApi.DeltaTime * _rotationSmoothPool.Get(e).Value;
                    view.Rotation = Quaternion.Lerp(view.Rotation, rotation.Value, delta);
                }
            }
        }
    }
}