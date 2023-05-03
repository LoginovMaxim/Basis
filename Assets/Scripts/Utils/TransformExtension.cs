using UnityEngine;

namespace Utils
{
    public static class TransformExtension
    {
        public static int GetActiveChildCount(this Transform transform)
        {
            var count = 0;
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    count++;
                }
            }

            return count;
        }
    }
}