using Basis.Example.Match.Ecs.Providers;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class InitShipPoolSystem : IEcsPreInitSystem
    {
        [EcsInject] private readonly IShipPrefabConfigProvider _shipPrefabConfigProvider;
        
        public void PreInit(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            /*foreach (var pool in _unitPool.EntityPool)
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
            }*/
        }
    }
}