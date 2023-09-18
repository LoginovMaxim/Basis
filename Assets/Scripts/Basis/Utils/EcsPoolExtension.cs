using Leopotam.EcsLite;

namespace Basis.Utils
{
    public static class EcsPoolExtension
    {
        public static ref TComponent GetOrAdd<TComponent>(this EcsPool<TComponent> pool, int entityId) 
            where TComponent : struct
        {
            if (pool.Has(entityId))
            {
                return ref pool.Get(entityId);
            }

            return ref pool.Add(entityId);
        }
        
        public static bool TryDel<TComponent>(this EcsPool<TComponent> pool, int entityId) 
            where TComponent : struct
        {
            if (!pool.Has(entityId))
            {
                return false;
            }
            
            pool.Del(entityId);
            return true;
        }
    }
}