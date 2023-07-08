using Basis.Ecs;
using Basis.Views;
using Leopotam.EcsLite;
using Project.Match.Ecs.Features.Rotations.Components;
using Project.Match.Ecs.Features.Scales.Components;
using UnityEngine;

namespace Project.Match.Ecs.Features.Rotations.Systems
{
    public sealed class SyncViewRotationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;
        
        private EcsWorld _world;
        private EcsFilter _rotationFilter;
        private EcsFilter _rotationSmoothFilter;
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
            
            _rotationFilter = _world.Filter<Scale>().End();
            _rotationSmoothFilter = _world.Filter<ScaleSmooth>().End();
            
            _rotationPool = _world.GetPool<Rotation>();
            _rotationSmoothPool = _world.GetPool<RotationSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            SyncRotation();
            SyncRotationSmooth();
        }

        private void SyncRotation()
        {
            foreach (var e in _rotationFilter)
            {
                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }
                
                var rotation = _rotationPool.Get(e);
                view.Rotation = rotation.Value;
            }
        }

        private void SyncRotationSmooth()
        {
            foreach (var e in _rotationSmoothFilter)
            {
                if (!_viewsProvider.TryGet(e, out var view))
                {
                    continue;
                }

                var rotationSmooth = _rotationSmoothPool.Get(e);
                var delta = _engineApi.DeltaTime * rotationSmooth.Smooth;
                view.Rotation = Quaternion.Lerp(view.Rotation, rotationSmooth.Value, delta);
            }
        }
    }
}