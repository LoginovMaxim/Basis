using Basis.App.Views;
using Basis.Ecs;
using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
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
                var scale = _scalePool.Get(e);

                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                view.Transform.localScale = scale.Value;
            }
        }

        private void SyncScaleSmooth()
        {
            foreach (var e in _scaleSmoothFilter)
            {
                var scaleSmooth = _scaleSmoothPool.Get(e);

                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                var delta = _engineApi.DeltaTime * scaleSmooth.Smooth;
                view.Transform.localScale = Vector3.Lerp(view.Transform.localScale, scaleSmooth.Value, delta);
            }
        }
    }
}