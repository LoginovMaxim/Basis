using Basis.App.Views;
using Basis.Ecs;
using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
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
            
            _positionFilter = _world.Filter<Scale>().End();
            _positionSmoothFilter = _world.Filter<ScaleSmooth>().End();
            
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
                var position = _positionPool.Get(e);

                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                view.Transform.position = position.Value;
            }
        }

        private void SyncPositionSmooth()
        {
            foreach (var e in _positionSmoothFilter)
            {
                var positionSmooth = _positionSmoothPool.Get(e);

                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                var delta = _engineApi.DeltaTime * positionSmooth.Smooth;
                view.Transform.position = Vector3.Lerp(view.Transform.position, positionSmooth.Value, delta);
            }
        }
    }
}