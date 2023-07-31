using UnityEngine;

namespace Basis.Utils
{
    public static class BezierUtils
    {
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return mT * p0 + t * p1;
        }
        
        public static Vector3 GetDerivative(Vector3 p0, Vector3 p1, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return p1 - p0;
        }
        
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return (mT * mT) * p0 + (2f * t * mT) * p1 + (t * t) * p2;
        }
        
        public static Vector3 GetDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return (2f * t - 2f) * p0 + (2f - 4f * t) * p1 + (2f * t) * p2;
        }
        
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return (mT * mT * mT) * p0 + (3f * t * mT * mT) * p1 + (3f * t * t * mT) * p2 + (t * t * t) * p3;
        }
        
        public static Vector3 GetDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1f - t;

            return (3f * mT * mT) * (p1 - p0) + (6f * t * mT) * (p2 - p1) + (3f * t * t) * (p3 - p2);
        }
        
        public static Vector3 GetPosition(Vector3 startPosition, Vector3 averagePosition, Vector3 endPosition, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1 - t;

            // Квадратичная кривая: https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B8%D0%B2%D0%B0%D1%8F_%D0%91%D0%B5%D0%B7%D1%8C%D0%B5
            return (mT * mT * startPosition) + (2 * t * mT * averagePosition) + (t * t * endPosition);
        }

        public static Vector3 GetPosition(Vector3 startPosition, Vector3 anchorStartPosition, Vector3 anchorEndPosition, Vector3 endPosition, float t)
        {
            t = Mathf.Clamp01(t);
            var mT = 1 - t;

            // Кубическая кривая: https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B8%D0%B2%D0%B0%D1%8F_%D0%91%D0%B5%D0%B7%D1%8C%D0%B5
            return (mT * mT * mT * startPosition) +
                   (3 * t * mT * mT * anchorStartPosition) +
                   (3 * t * t * mT * anchorEndPosition) +
                   (t * t * t * endPosition);
        }
    }
}