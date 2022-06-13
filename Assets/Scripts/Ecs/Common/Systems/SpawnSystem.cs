using Ecs.Common.Components;
using Leopotam.Ecs;

namespace Ecs.Common.Systems
{
    public sealed class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<SpawnComponent> _filter = null;

        private IPrefabFactory _prefabFactory;

        public void PreInit()
        {
            _prefabFactory.SetWorld(_world);
        }

        public void Run()
        {
            if (_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref var spawnEntity = ref _filter.GetEntity(i);
                ref var spawn = ref _filter.Get1(i);

                _prefabFactory.Spawn(spawn);
                spawnEntity.Del<SpawnComponent>();
            }
        }
    }
}
