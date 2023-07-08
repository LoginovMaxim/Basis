using UnityEngine;

namespace Basis.Utils
{
    public static class StringExtension
    {
        public static string WithColor(this string value, Color color)
        {
            var hexColor = ColorUtility.ToHtmlStringRGB(color);
            return $"<color=#{hexColor}>{value}</color>";
        }

        public static string GetTypeName(this string value)
        {
            var values = value.Split('.');
            return values[^1];
        }
    }
}