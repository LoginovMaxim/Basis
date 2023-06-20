using System.Collections.Generic;

namespace Basis.App.Configs
{
    public interface IBinaryConfig
    {
        bool Empty { get; }
        long Timestamp { get; }
        List<IConfigEntity> Entities { get; }
        byte[] Raw { get; }
        bool Load(byte[] bytes, long timestamp);
        EntityType GetEntity<EntityType>(string id) where EntityType : IConfigEntity;
        List<EntityType> GetEntities<EntityType>() where EntityType : IConfigEntity;
    }
}