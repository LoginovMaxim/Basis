using Leopotam.EcsLite;

namespace Ecs
{
    public abstract class MonoLink<T> : MonoLinkBase where T : struct
    {
        public T Value;

        public override void Make(ref EcsPackedEntityWithWorld entity)
        {
            if (!entity.Unpack(out var world, out var unpackedEntity))
            {
                return;
            }

            var pool = world.GetPool<T>();
            ref var component = ref pool.Add(unpackedEntity);
            component = Value;
        }
    }
}
