using UnityEngine;

namespace Basis.Utils
{
    public static class Vector3Extension
    {
        public static Vector3 LookRotationEuler(this Vector3 direction)
        {
            return direction == Vector3.zero ? Vector3.zero : Quaternion.LookRotation(direction).eulerAngles;
        }
        
        public static Quaternion LookRotation(this Vector3 direction)
        {
            return direction == Vector3.zero ? Quaternion.identity : Quaternion.LookRotation(direction);
        }
    }
}