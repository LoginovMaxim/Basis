using System;
using System.Collections.Generic;
using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Pool
{
    public sealed class EntityPool<TPoolObject> : IEntityPool where TPoolObject : IPoolObject
    {
        private readonly IPrefabFactory _prefabFactory;
        private readonly TPoolObject _poolObject;
        private readonly Transform _parent;

        private List<EcsPackedEntityWithWorld> _entityPool = new List<EcsPackedEntityWithWorld>();
        private SpawnComponent _spawnComponent;
        private int _poolSize;

        public EntityPool(IPrefabFactory prefabFactory, TPoolObject poolObject, Transform parent)
        {
            _prefabFactory = prefabFactory;
            _poolObject = poolObject;
            _parent = parent;
        }

        private void Initialize(SpawnComponent spawnComponent, int poolSize)
        {
            _spawnComponent = spawnComponent;
            _poolSize = poolSize;
            
            for (var i = 0; i < _poolSize; i++)
            {
                var newEntity = _prefabFactory.Spawn(_spawnComponent, _parent);
                _entityPool.Add(newEntity);
                Despawn(newEntity);
            }
        }

        private EcsPackedEntityWithWorld Spawn(SpawnData spawnData)
        {
            foreach (var entity in _entityPool)
            {
                if (!entity.Unpack(out var world, out var unpackedEntity))
                {
                    continue;
                }

                var gameObjectPool = world.GetPool<GameObjectComponent>();
                ref var gameObject = ref gameObjectPool.Get(unpackedEntity).GameObject;
                if (gameObject == null)
                {
                    Debug.Break();
                    Debug.Log("Pool entity missing gameObject");
                }
                
                if (gameObject.activeSelf)
                {
                    continue;
                }
                
                var transformPool = world.GetPool<TransformComponent>();
                ref var transform = ref transformPool.Get(unpackedEntity).Transform;
                transform.position = spawnData.Position;

                gameObject.layer = spawnData.Layer;
                gameObject.SetActive(true);

                var rigidbodyPool = world.GetPool<RigidbodyComponent>();
                if (rigidbodyPool.Has(unpackedEntity))
                {
                    ref var rigidbody = ref rigidbodyPool.Get(unpackedEntity).Rigidbody;
                    rigidbody.velocity = Vector3.zero;
                }

                var activePool = world.GetPool<ActiveComponent>();
                if (!activePool.Has(unpackedEntity))
                {
                    activePool.Add(unpackedEntity);
                }

                return entity;
            }

            return Create(spawnData);
        }

        private EcsPackedEntityWithWorld Create(SpawnData spawnData)
        {
            var entity = _prefabFactory.Spawn(_spawnComponent, _parent);

            if (!entity.Unpack(out var world, out var unpackedEntity))
            {
                throw new Exception($"Cannot unpack created entity {entity}");
            }
            
            var transformPool = world.GetPool<TransformComponent>();
            ref var transform = ref transformPool.Get(unpackedEntity).Transform;
            transform.position = spawnData.Position;
            
            var gameObjectPool = world.GetPool<GameObjectComponent>();
            ref var gameObject = ref gameObjectPool.Get(unpackedEntity).GameObject;
            gameObject.layer = spawnData.Layer;

            var activePool = world.GetPool<ActiveComponent>();
            if (!activePool.Has(unpackedEntity))
            {
                activePool.Add(unpackedEntity);
            }
            
            _entityPool.Add(entity);
            return entity;
        }

        private void Despawn(EcsPackedEntityWithWorld entity)
        {
            if (!entity.Unpack(out var world, out var unpackedEntity))
            {
                throw new Exception($"Cannot unpack entity {entity} for despawn");
            }

            var gameObjectPool = world.GetPool<GameObjectComponent>();
            var activePool = world.GetPool<ActiveComponent>();
            
            ref var gameObject = ref gameObjectPool.Get(unpackedEntity).GameObject;
            gameObject.SetActive(false);

            if (activePool.Has(unpackedEntity))
            {
                activePool.Del(unpackedEntity);
            }
        }

        #region IEntityPool

        IPoolObject IEntityPool.PoolObject => _poolObject;

        void IEntityPool.Initialize(SpawnComponent spawnComponent, int poolSize)
        {
            Initialize(spawnComponent, poolSize);
        }

        EcsPackedEntityWithWorld IEntityPool.Spawn(SpawnData spawnData)
        {
            return Spawn(spawnData);
        }

        void IEntityPool.Despawn(EcsPackedEntityWithWorld entity)
        {
            Despawn(entity);
        }

        #endregion
    }
}