using Leopotam.Ecs;

namespace Ecs.Common.Systems
{
    public sealed class ConvertAllMonoEntitiesSystem : IEcsInitSystem
    {
        private IPrefabFactory _prefabFactory;
        
        public void Init()
        {
            _prefabFactory.ConvertAllMonoEntitiesInScene();
        }
    }
}