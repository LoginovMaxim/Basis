using Leopotam.EcsLite;

namespace Basis.Ecs.Common.Systems
{
    public sealed class OneFrameSystem<T> : IEcsPostRunSystem where T : struct
    {
        public void PostRun(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            var pool = world.GetPool<T>();

            foreach (var entity in filter)
            {
                pool.Del(entity);
            }
        }
    }
}