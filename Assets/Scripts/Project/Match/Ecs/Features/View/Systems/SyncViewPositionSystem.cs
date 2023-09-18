using Basis.Ecs;
using Basis.Views;
using Leopotam.EcsLite;
using Project.Match.Ecs.Features.View.Components;
using UnityEngine;

namespace Project.Match.Ecs.Features.View.Systems
{
    public sealed class SyncViewPositionSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _positionFilter;
        private EcsFilter _positionSmoothFilter;
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
                .Inc<ViewTag>()
                .Inc<ActiveTag>()
                .End();
            
            _positionSmoothFilter = _world
                .Filter<PositionSmooth>()
                .Inc<ViewTag>()
                .Inc<ActiveTag>()
                .End();
            
            _positionPool = _world.GetPool<Position>();
            _positionSmoothPool = _world.GetPool<PositionSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            SyncPosition();
            SyncPositionSmooth();
        }

        private void SyncPosition()
        {
            foreach (var e in _positionFilter)
            {
                if (!_viewsProvider.TryGet<IViewObject>(e, out var view))
                {
                    continue;
                }

                var position = _positionPool.Get(e);
                view.Position = position.Value;
            }
        }

        private void SyncPositionSmooth()
        {
            foreach (var e in _positionSmoothFilter)
            {
                if (!_viewsProvider.TryGet<IViewObject>(e, out var view))
                {
                    continue;
                }

                var positionSmooth = _positionSmoothPool.Get(e);
                var delta = _engineApi.DeltaTime * positionSmooth.Smooth;
                view.Position = Vector3.Lerp(view.Position, positionSmooth.Value, delta);
            }
        }
    }
}