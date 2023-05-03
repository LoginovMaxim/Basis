using Ecs.Common.Components;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Ecs.Common.Systems
{
    public sealed class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        [EcsInject] private readonly IPrefabFactory _prefabFactory;
        /*[EcsInject] private readonly IUnitPrefabConfigProvider _unitPrefabConfigProvider;
        [EcsInject] private readonly IUnitPool _unitPool;
        [EcsInject] private readonly IProjectilePrefabConfigProvider _projectilePrefabConfigProvider;
        [EcsInject] private readonly IProjectilePool _projectilePool;*/

        public void PreInit(IEcsSystems systems)
        {
            /*foreach (var pool in _unitPool.UnitPool)
            {
                if (pool.PoolObject is not IUnit unit)
                {
                    continue;
                }
                
                var unitSpawn = new SpawnComponent
                {
                    Prefab = _unitPrefabConfigProvider.GetUnitPrefab(unit.UnitId),
                    Position = Vector3.zero,
                    Rotation = Quaternion.identity
                };
                
                pool.Initialize(unitSpawn, pool.PoolObject.InitialPoolSize);
            }

            foreach (var pool in _projectilePool.ProjectilePool)
            {
                if (pool.PoolObject is not IProjectile projectile)
                {
                    continue;
                }
                
                var projectileSpawn = new SpawnComponent
                {
                    Prefab = _projectilePrefabConfigProvider.GetProjectilePrefab(projectile.ProjectileId),
                    Position = Vector3.zero,
                    Rotation = Quaternion.identity
                };
                
                pool.Initialize(projectileSpawn, pool.PoolObject.InitialPoolSize);
            }*/
        }

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var spawnFilter = world.Filter<SpawnComponent>().End();
            var spawns = world.GetPool<SpawnComponent>();

            foreach (var entity in spawnFilter)
            {
                var emitEffect = spawns.Get(entity);

                _prefabFactory.Spawn(emitEffect);
                spawns.Del(entity);
            }
        }
    }
}
