using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs
{
    public interface IPrefabFactory
    {
        EcsPackedEntityWithWorld Spawn(SpawnComponent spawnComponent, Transform parent = null);

        void Despawn(EcsPackedEntityWithWorld entity);

        void ConvertAllMonoEntitiesInScene(EcsWorld world);
    }
}