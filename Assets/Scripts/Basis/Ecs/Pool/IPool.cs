﻿using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Basis.Ecs.Pool
{
    public interface IPool
    {
        List<IEntityPool> EntityPool { get; }
        EcsPackedEntityWithWorld Spawn(int id, SpawnData spawnData);
        void Despawn(int id, EcsPackedEntityWithWorld entity);
    }
}