using Ecs.Common.Components;
using Example.Match.Ecs.Components;
using Example.Match.Pools.Ships;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Example.Match.Ecs.Systems
{
    public sealed class DespawnShipSystem : IEcsRunSystem
    {
        [EcsInject] private readonly IShipPool _shipPool;
        
        public void Run(IEcsSystems systems)
        {
            if (!Input.GetKeyDown(KeyCode.Delete))
            {
                return;
            }

            var world = systems.GetWorld();
            var shipFilter = world.Filter<ShipTagComponent>().Inc<ActiveComponent>().End();
            var shipPool = world.GetPool<ShipTagComponent>();

            foreach (var entity in shipFilter)
            {
                var ship = shipPool.Get(entity);
                _shipPool.Despawn((int) ship.ShipId, world.PackEntityWithWorld(entity));
                break;
            }
        }
    }
}