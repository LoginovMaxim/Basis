using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Ecs.Common.Systems
{
    public sealed class ConvertAllMonoEntitiesSystem : IEcsRunSystem
    {
        [EcsInject] private readonly IPrefabFactory _prefabFactory;

        public void Run(IEcsSystems systems)
        {
            _prefabFactory.ConvertAllMonoEntitiesInScene();
        }
    }
}