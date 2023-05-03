using Ecs.Common.Components;
using Leopotam.EcsLite;

namespace Ecs.Common.MonoLinks
{
    public sealed class GameObjectMonoLink : MonoLink<GameObjectComponent>
    {
        public override void Make(ref EcsPackedEntityWithWorld entity)
        {
            if (!entity.Unpack(out var world, out var unpackedEntity))
            {
                return;
            }

            var pool = world.GetPool<GameObjectComponent>();
            ref var component = ref pool.Add(unpackedEntity);
            component = new GameObjectComponent
            {
                GameObject = gameObject
            };
        }
    }
}
