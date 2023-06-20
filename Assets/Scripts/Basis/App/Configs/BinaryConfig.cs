using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Basis.App.Configs
{
    public sealed class BinaryConfig : IBinaryConfig
    {
        private readonly List<IConfigEntity> _entities = new List<IConfigEntity>();
        private readonly Dictionary<string, IConfigEntity> _entityMap = new Dictionary<string, IConfigEntity>();
        private readonly Dictionary<Type, List<IConfigEntity>> _typeToEntityMap = new Dictionary<Type, List<IConfigEntity>>();

        private byte[] _raw;
        private long _timestamp;

        private EntityType GetEntity<EntityType>(string id) where EntityType : IConfigEntity
        {
            if (!_entityMap.TryGetValue(id, out var entity))
            {
                return default;
            }
            
            if (entity is EntityType typedEntity)
            {
                return typedEntity;
            }
            
            return default;
        }

        private List<EntityType> GetEntities<EntityType>() where EntityType : IConfigEntity
        {
            var type = typeof(EntityType);
            if (!_typeToEntityMap.TryGetValue(type, out var entities))
            {
                entities = new List<IConfigEntity>();
                for (var i = 0; i < _entities.Count; ++i)
                {
                    var entity = _entities[i];
                    if (entity is EntityType)
                    {
                        entities.Add(entity);
                    }
                }
                _typeToEntityMap.Add(type, entities);
            }
            var typedEntities = new List<EntityType>();
            for (var i = 0; i < entities.Count; ++i)
            {
                typedEntities.Add((EntityType)entities[i]);
            }
            return typedEntities;
        }

        private bool Load(byte[] bytes, long timestamp)
        {
            try
            {
                var entities = BinaryConfigUtils.Load(bytes);
                var entityMap = new Dictionary<string, IConfigEntity>();
                for (var i = 0; i < entities.Count; ++i)
                {
                    var entity = entities[i];
                    entityMap.Add(entity.Id, entity);
                }
                _entities.Clear();
                _entityMap.Clear();
                _typeToEntityMap.Clear();
                _entities.AddRange(entities);
                foreach (var key in entityMap.Keys)
                {
                    _entityMap.Add(key, entityMap[key]);
                }
                _raw = bytes;
                _timestamp = timestamp;
                return true;
            }
            catch (Exception exception)
            {
                Debug.Log($"{ exception }");
            }
            return false;
        }

        public static byte[] Save(List<IConfigEntity> entities)
        {
            try
            {
                return BinaryConfigUtils.Save(entities);
            }
            catch (Exception exception)
            {
                Debug.LogError($"{ exception }");
            }
            return null;
        }

        #region IBinaryConfig

        bool IBinaryConfig.Empty => _entities.Count == 0;

        long IBinaryConfig.Timestamp => _timestamp;

        List<IConfigEntity> IBinaryConfig.Entities => _entities;

        byte[] IBinaryConfig.Raw => _raw;

        EntityType IBinaryConfig.GetEntity<EntityType>(string id)
        {
            return GetEntity<EntityType>(id);
        }

        List<EntityType> IBinaryConfig.GetEntities<EntityType>()
        {
            return GetEntities<EntityType>();
        }

        bool IBinaryConfig.Load(byte[] bytes, long timestamp)
        {
            return Load(bytes, timestamp);
        }

        #endregion

        #region Types

        public sealed class Factory : PlaceholderFactory<BinaryConfig>, IBinaryConfigFactory {}

        #endregion
    }
}