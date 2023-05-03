using System;

namespace Utils
{
    public static class EnumExtension
    {
        public static string GetEnumName<T>(T value)
        {
            return Enum.GetName(typeof(T), value);
        }
    }
}