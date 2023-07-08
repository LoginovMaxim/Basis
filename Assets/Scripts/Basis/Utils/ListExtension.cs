using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Basis.Utils
{
    public static class ListExtension
    {
        public static bool TryGetRandom<T>(this List<T> list, out T randomValue)
        {
            randomValue = default;
            if (list.IsEmpty())
            {
                return false;
            }
            
            randomValue = list[Random.Range(0, list.Count)];
            return true;
        }
    }
}