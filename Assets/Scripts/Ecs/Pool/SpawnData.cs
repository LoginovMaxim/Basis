using UnityEngine;

namespace Ecs.Pool
{
    public sealed class SpawnData
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly int Layer;

        public SpawnData(Vector3 position, Quaternion rotation, int layer)
        {
            Position = position;
            Rotation = rotation;
            Layer = layer;
        }
    }
}