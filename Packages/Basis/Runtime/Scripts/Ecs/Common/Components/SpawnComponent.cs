using UnityEngine;

namespace Ecs.Common.Components
{
    public struct SpawnComponent
    {
        public GameObject Prefab;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        public Transform Parent;
    }
}
