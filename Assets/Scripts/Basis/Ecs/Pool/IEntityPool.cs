using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;

namespace Basis.Ecs.Pool
{
    public interface IEntityPool
    {
        IPoolObject PoolObject { get; }
        void Initialize(SpawnComponent spawnComponent, int poolSize);
        EcsPackedEntityWithWorld Spawn(SpawnData spawnData);
        void Despawn(EcsPackedEntityWithWorld entity);
    }
}