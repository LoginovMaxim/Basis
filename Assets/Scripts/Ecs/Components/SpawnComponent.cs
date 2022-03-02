using UnityEngine;

namespace CoreECS.Components
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