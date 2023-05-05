using Ecs.Pool;
using Example.Match.Pools.Ships;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Example.Match.Ecs.Systems
{
    public sealed class SpawnShipSystem : IEcsRunSystem
    {
        [EcsInject] private readonly IShipPool _shipPool;
        
        public void Run(IEcsSystems systems)
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            var shipSpawnPosition = new Vector3(25, 50, 25);
            var shipSpawnData = new SpawnData(shipSpawnPosition, Quaternion.identity, 0);
            _shipPool.Spawn((int) ShipId.SmallShip, shipSpawnData);
        }
    }
}