using Basis.Ecs.Common.Components;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Ecs.Common.Systems
{
    public sealed class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        [EcsInject] private readonly IPrefabFactory _prefabFactory;

        public void PreInit(IEcsSystems systems)
        {
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
