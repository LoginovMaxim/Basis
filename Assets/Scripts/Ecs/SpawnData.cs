using UnityEngine;

namespace Ecs
{
    public sealed class SpawnData
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Vector3 Scale;
        public readonly int Layer;

        public SpawnData(Vector3 position, Quaternion rotation, Vector3 scale, int layer)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Layer = layer;
        }
    }
}