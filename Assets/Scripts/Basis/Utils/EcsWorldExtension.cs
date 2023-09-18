using Leopotam.EcsLite;

namespace Basis.Utils
{
    public static class EcsWorldExtension
    {
        public static bool TryAddEcsComponent<TComponent>(this EcsWorld world, int entityId) 
            where TComponent : struct
        {
            var componentPool = world.GetPool<TComponent>();
            if (componentPool.Has(entityId))
            {
                return false;
            }
            
            componentPool.Add(entityId);
            return true;
        }
        
        public static ref TComponent GetOrAddEcsComponent<TComponent>(this EcsWorld world, int entityId) 
            where TComponent : struct
        {
            var componentPool = world.GetPool<TComponent>();
            if (componentPool.Has(entityId))
            {
                return ref componentPool.Get(entityId);
            }
            
            return ref componentPool.Add(entityId);
        }
        
        public static bool TryDelEcsComponent<TComponent>(this EcsWorld world, int entityId) 
            where TComponent : struct
        {
            var componentPool = world.GetPool<TComponent>();
            if (!componentPool.Has(entityId))
            {
                return false;
            }
            
            componentPool.Del(entityId);
            return true;
        }
    }
}