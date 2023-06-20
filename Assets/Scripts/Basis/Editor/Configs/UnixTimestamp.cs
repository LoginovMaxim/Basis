using System;

namespace Basis.Editor.Configs
{
    public static class UnixTimestamp
    {
        public readonly static DateTime UnixEpoch = new DateTime(1970, 1, 1);

        public static long Now => DateTime.Now.ToUnixTimestamp();

        public static long UtcNow => DateTime.UtcNow.ToUnixTimestamp();

        public static DateTime ToDateTime(this long timestamp)
        {
            return UnixEpoch + TimeSpan.FromSeconds(timestamp);
        }

        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return (long)dateTime.Subtract(UnixEpoch).TotalSeconds;
        }
    }
}