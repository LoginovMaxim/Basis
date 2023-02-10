using Ecs.Common.Components;
using Leopotam.Ecs;

namespace Ecs
{
    public interface IEntityPool
    {
        IPoolObject PoolObject { get; }
        void Initialize(SpawnComponent spawnComponent, int poolSize);
        EcsEntity Spawn(SpawnData spawnData);
        EcsEntity GetReadySpawnEntity();
        void Despawn(EcsEntity entity);
    }
}