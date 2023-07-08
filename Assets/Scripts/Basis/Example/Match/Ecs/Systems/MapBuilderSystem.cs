using Basis.App.Pool;
using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Components;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Views;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class MapBuilderSystem : IEcsInitSystem
    {
        private readonly IMapConfigProvider _mapConfigProvider;
        private readonly IPoolService _poolService;

        public MapBuilderSystem(IMapConfigProvider mapConfigProvider, IPoolService poolService)
        {
            _mapConfigProvider = mapConfigProvider;
            _poolService = poolService;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var seaBlockTagPool = world.GetPool<SeaBlockTag>();
            var positionPool = world.GetPool<Position>();
            var scalePool = world.GetPool<Scale>();
            var positionSmoothPool = world.GetPool<PositionSmooth>();
            var scaleSmoothPool = world.GetPool<ScaleSmooth>();
            
            for (var i = 0; i < _mapConfigProvider.MapSize; i++)
            {
                for (var j = 0; j < _mapConfigProvider.MapSize; j++)
                {
                    var seaBlockPosition = new Vector3(i, 0, j);
                    
                    var seaBlockEntityId = world.NewEntity();
                    seaBlockTagPool.Add(seaBlockEntityId);
                    //positionPool.Add(seaBlockEntityId).Value = seaBlockPosition;
                    //scalePool.Add(seaBlockEntityId).Value = Vector3.one;
                    ref var positionSmooth = ref positionSmoothPool.Add(seaBlockEntityId);
                    positionSmooth.Value = seaBlockPosition;
                    positionSmooth.Smooth = 0.5f;
                    
                    ref var scaleSmooth = ref scaleSmoothPool.Add(seaBlockEntityId);
                    scaleSmooth.Value = Vector3.one;
                    scaleSmooth.Smooth = 5f;

                    _poolService.TrySpawnView<SampleSeaBlockView>(seaBlockEntityId);
                }
            }
        }
    }
}