using System.Collections.Generic;

namespace Basis.Configs.BinaryConfigs
{
    public static class BinaryConfigUtils
    {
        public static List<IConfigEntity> Load(byte[] bytes)
        {
            return SerializationUtils.Deserialize<List<IConfigEntity>>(bytes);
        }

        public static byte[] Save(List<IConfigEntity> entities)
        {
            return SerializationUtils.Serialize(entities);
        }
    }
}