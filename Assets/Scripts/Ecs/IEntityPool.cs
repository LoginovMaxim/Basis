﻿using Ecs.Common.Components;
using Leopotam.EcsLite;

namespace Ecs
{
    public interface IEntityPool
    {
        IPoolObject PoolObject { get; }
        void Initialize(SpawnComponent spawnComponent, int poolSize);
        EcsPackedEntityWithWorld Spawn(SpawnData spawnData);
        void Despawn(EcsPackedEntityWithWorld entity);
    }
}