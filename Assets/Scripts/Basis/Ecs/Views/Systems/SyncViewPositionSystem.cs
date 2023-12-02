using Basis.Ecs.Views.Components;
using Basis.Views;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Views.Systems
{
    public sealed class SyncViewPositionSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _positionFilter;
        private EcsPool<Position> _positionPool;
        private EcsPool<PositionSmooth> _positionSmoothPool;

        public SyncViewPositionSystem(IEngineApi engineApi, IViewsProvider viewsProvider)
        {
            _viewsProvider = viewsProvider;
            _engineApi = engineApi;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _positionFilter = _world
                .Filter<Position>()
                .Inc<ActiveTag>()
                .Exc<AnimationTag>()
                .End();
            
            _positionPool = _world.GetPool<Position>();
            _positionSmoothPool = _world.GetPool<PositionSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var e in _positionFilter)
            {
                if (!_viewsProvider.TryGet<IViewObject>(e, out var view))
                {
                    continue;
                }

                var position = _positionPool.Get(e);
                
                if (!_positionSmoothPool.Has(e))
                {
                    view.Position = position.Value;
                }
                else
                {
                    var delta = _engineApi.DeltaTime * _positionSmoothPool.Get(e).Value;
                    view.Position = Vector3.Lerp(view.Position, position.Value, delta);
                }
            }
        }
    }
}