using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Ecs.Common.Systems
{
    public sealed class ConvertAllMonoEntitiesSystem : IEcsInitSystem
    {
        [EcsInject] private readonly IPrefabFactory _prefabFactory;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _prefabFactory.ConvertAllMonoEntitiesInScene(world);
        }
    }
}