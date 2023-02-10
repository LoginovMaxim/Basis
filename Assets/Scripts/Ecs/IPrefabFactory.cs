using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs
{
    public interface IPrefabFactory
    {
        void SetWorld(EcsWorld world);

        EcsEntity Spawn(SpawnComponent spawnComponent, Transform parent = null);

        void Despawn(EcsEntity entity);

        void ConvertAllMonoEntitiesInScene();
    }
}