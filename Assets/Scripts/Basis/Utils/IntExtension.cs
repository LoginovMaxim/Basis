using UnityEngine;

namespace Basis.Utils
{
    public static class IntExtension
    {
        public static bool IsCounterOver(this int targetValue, ref int elapsedValue)
        {
            if (elapsedValue++ < targetValue)
            {
                return false;
            }

            elapsedValue = 0;
            return true;
        }
        
        public static bool IsPreCounterOver(this int targetValue, ref int elapsedValue)
        {
            if (++elapsedValue < targetValue)
            {
                return false;
            }

            elapsedValue = 0;
            return true;
        }
        
        public static int WithRange(this int value, int range)
        {
            return Random.Range(value - range, value + range);
        }
        
        public static string ToRomeNumber(this int value)
        {
            return value switch
            {
                1 => "I",
                2 => "II",
                3 => "III",
                _ => "I"
            };
        }
    }
}