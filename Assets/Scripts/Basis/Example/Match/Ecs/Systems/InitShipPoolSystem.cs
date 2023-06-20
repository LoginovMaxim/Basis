using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Pools.Ships;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class InitShipPoolSystem : IEcsPreInitSystem
    {
        [EcsInject] private readonly IShipPrefabConfigProvider _shipPrefabConfigProvider;
        [EcsInject] private readonly IShipPool _unitPool;
        
        public void PreInit(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            foreach (var pool in _unitPool.EntityPool)
            {
                if (pool.PoolObject is not IShip ship)
                {
                    continue;
                }

                var shipPrefab = _shipPrefabConfigProvider.GetShipPrefabById(ship.ShipId);
                var unitSpawn = new SpawnComponent(
                    shipPrefab, 
                    Vector3.zero, 
                    Quaternion.identity, 
                    Vector3.one, 
                    null, 
                    world);
                
                pool.Initialize(unitSpawn, pool.PoolObject.InitialPoolSize);
            }
        }
    }
}