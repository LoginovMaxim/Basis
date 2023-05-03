using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Ecs.Common.Systems
{
    public sealed class ConvertAllMonoEntitiesSystem : IEcsInitSystem, IEcsRunSystem
    {
        [EcsInject] private readonly IPrefabFactory _prefabFactory;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _prefabFactory.ConvertAllMonoEntitiesInScene(world);
        }
        
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _prefabFactory.ConvertAllMonoEntitiesInScene(world);
        }
    }
}