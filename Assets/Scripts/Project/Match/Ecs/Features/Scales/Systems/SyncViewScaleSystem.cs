using Basis.Ecs;
using Basis.Views;
using Leopotam.EcsLite;
using Project.Match.Ecs.Features.Scales.Components;
using UnityEngine;

namespace Project.Match.Ecs.Features.Scales.Systems
{
    public sealed class SyncViewScaleSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _scaleFilter;
        private EcsFilter _scaleSmoothFilter;
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
            
            _scaleFilter = _world.Filter<Scale>().End();
            _scaleSmoothFilter = _world.Filter<ScaleSmooth>().End();
            
            _scalePool = _world.GetPool<Scale>();
            _scaleSmoothPool = _world.GetPool<ScaleSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            SyncScale();
            SyncScaleSmooth();
        }

        private void SyncScale()
        {
            foreach (var e in _scaleFilter)
            {
                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                var scale = _scalePool.Get(e);
                view.LocalScale = scale.Value;
            }
        }

        private void SyncScaleSmooth()
        {
            foreach (var e in _scaleSmoothFilter)
            {
                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                var scaleSmooth = _scaleSmoothPool.Get(e);
                var delta = _engineApi.DeltaTime * scaleSmooth.Smooth;
                view.LocalScale = Vector3.Lerp(view.LocalScale, scaleSmooth.Value, delta);
            }
        }
    }
}