using UnityEngine;

namespace Basis.Utils
{
    public static class FloatExtension
    {
        public static bool IsTimeOver(this float duration, ref float elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime < duration)
            {
                return false;
            }

            elapsedTime = 0;
            return true;
        }
        
        public static bool IsTimeOverDown(this float duration, ref float elapsedTime)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime > 0)
            {
                return false;
            }

            elapsedTime = duration;
            return true;
        }
        
        public static float WithRange(this float value, float range)
        {
            return Random.Range(value - range, value + range);
        }
        
        public static void WithRangeSelf(ref this float value, float range)
        {
            value = Random.Range(value - range, value + range);
        }
    }
}