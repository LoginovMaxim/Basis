using Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Ecs
{
    public interface IPrefabFactory
    {
        void SetWorld(EcsWorld world);

        EcsPackedEntityWithWorld Spawn(SpawnComponent spawnComponent, Transform parent = null);

        void Despawn(EcsPackedEntityWithWorld entity);

        void ConvertAllMonoEntitiesInScene();
    }
}