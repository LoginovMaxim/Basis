using Ecs.Common.Components;
using Leopotam.Ecs;

namespace Ecs
{
    public interface IPrefabFactory
    {
        void SetWorld(EcsWorld world);

        void Spawn(SpawnComponent spawnComponent);

        void Despawn(EcsEntity entity);

        void ConvertAllMonoEntitiesInScene();
    }
}