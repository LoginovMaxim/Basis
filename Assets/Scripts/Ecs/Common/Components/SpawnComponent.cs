using Leopotam.EcsLite;
using UnityEngine;

namespace Ecs.Common.Components
{
    public struct SpawnComponent
    {
        public readonly GameObject Prefab;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Vector3 Scale;
        public readonly Transform Parent;
        public readonly EcsWorld World;

        public SpawnComponent(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 scale, Transform parent, EcsWorld world)
        {
            Prefab = prefab;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Parent = parent;
            World = world;
        }
    }
}
