using Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace Utils
{
    public static class EcsUtils
    {
        public static bool TryGetEcsComponent<T>(MonoBehaviour gameObject, out T component) where T : struct
        {
            component = default;
            if (!gameObject.TryGetComponent(out MonoEntity monoEntity))
            {
                return false;
            }

            if (!monoEntity.Entity.Has<T>())
            {
                return false;
            }

            component = monoEntity.Entity.Get<T>();
            return true;
        }
    }
}