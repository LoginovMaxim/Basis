using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Providers;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class MapBuilderSystem : IEcsInitSystem
    {
        [EcsInject] private readonly IMapConfigProvider _mapConfigProvider;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var spawns = world.GetPool<SpawnComponent>();
            
            for (var i = 0; i < _mapConfigProvider.MapSize; i++)
            {
                for (var j = 0; j < _mapConfigProvider.MapSize; j++)
                {
                    var entity = world.NewEntity();
                    ref var spawn = ref spawns.Add(entity);
                    spawn = new SpawnComponent(
                        _mapConfigProvider.CubePrefab, 
                        new Vector3(i, 0, j), 
                        Quaternion.identity, 
                        Vector3.one, 
                        null, 
                        world);
                }
            }
        }
    }
}