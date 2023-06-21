using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basis.App.Configs
{
    public static class SerializationUtils
    {
        private const string AssamblyPlaceHolder = "[ASSEMBLY]";

        private static readonly SerializationBinder _loadBinder = new SerializationBinder(AssamblyPlaceHolder, $"{ Assembly.GetExecutingAssembly().GetName().Name },");
        private static readonly SerializationBinder _saveBinder = new SerializationBinder($"{ Assembly.GetExecutingAssembly().GetName().Name },", AssamblyPlaceHolder);

        private static readonly BinaryFormatter _loadBinaryFormatter = new BinaryFormatter { Binder = _loadBinder };
        private static readonly BinaryFormatter _saveBinaryFormatter = new BinaryFormatter { Binder = _saveBinder };

        public static Type Deserialize<Type>(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);
            return (Type)_loadBinaryFormatter.Deserialize(memoryStream);
        }

        public static Type Deserialize<Type>(ArraySegment<byte> arraySerment)
        {
            using var memoryStream = new MemoryStream(arraySerment.Array, arraySerment.Offset, arraySerment.Count);
            return (Type)_loadBinaryFormatter.Deserialize(memoryStream);
        }

        public static byte[] Serialize<Type>(Type obj)
        {
            using var memoryStream = new MemoryStream();
            _saveBinaryFormatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }
    }
}