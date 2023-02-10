using System.Collections.Generic;
using System.Linq;
using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs
{
    public sealed class EntityPool<TPoolObject> : IEntityPool where TPoolObject : IPoolObject
    {
        private readonly IPrefabFactory _prefabFactory;
        private readonly TPoolObject _poolObject;
        private readonly Transform _parent;

        private List<EcsEntity> _entityPool = new List<EcsEntity>();
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

        private EcsEntity Spawn(SpawnData spawnData)
        {
            foreach (var entity in _entityPool)
            {
                var gameObject = entity.Get<GameObjectComponent>().GameObject;
                if (gameObject == null)
                {
                    Debug.Break();
                    Debug.Log("Pool entity missing gameObject");
                }
                
                if (gameObject.activeSelf)
                {
                    continue;
                }
                
                ref var transform = ref entity.Get<TransformComponent>().Transform;
                transform.position = spawnData.Position;
                transform.rotation = spawnData.Rotation;
                transform.localScale = spawnData.Scale;

                gameObject.layer = spawnData.Layer;
                gameObject.SetActive(true);

                if (entity.Has<RigidbodyComponent>())
                {
                    ref var rigidbody = ref entity.Get<RigidbodyComponent>().Rigidbody;
                    rigidbody.velocity = Vector3.zero;
                }
                
                return entity;
            }
            
            var newEntity = _prefabFactory.Spawn(_spawnComponent, _parent);
            _entityPool.Add(newEntity);
            
            ref var newTransform = ref _entityPool.Last().Get<TransformComponent>().Transform;
            newTransform.position = spawnData.Position;
            newTransform.rotation = spawnData.Rotation;
            newTransform.localScale = spawnData.Scale;
            
            ref var newGameObject = ref _entityPool.Last().Get<GameObjectComponent>().GameObject;
            newGameObject.layer = spawnData.Layer;
            
            return newEntity;
        }

        private EcsEntity GetReadySpawnEntity()
        {
            foreach (var entity in _entityPool)
            {
                var gameObject = entity.Get<GameObjectComponent>().GameObject;
                if (gameObject == null)
                {
                    Debug.Break();
                    Debug.Log("Pool entity missing gameObject");
                }

                if (gameObject.activeSelf)
                {
                    continue;
                }

                return entity;
            }
            
            var newEntity = _prefabFactory.Spawn(_spawnComponent, _parent);
            _entityPool.Add(newEntity);
            
            newEntity.Get<GameObjectComponent>().GameObject.SetActive(false);
            return newEntity;
        }

        private void Despawn(EcsEntity entity)
        {
            var gameObject = entity.Get<GameObjectComponent>().GameObject;
            gameObject.SetActive(false);
        }

        #region IEntityPool

        IPoolObject IEntityPool.PoolObject => _poolObject;

        void IEntityPool.Initialize(SpawnComponent spawnComponent, int poolSize)
        {
            Initialize(spawnComponent, poolSize);
        }

        EcsEntity IEntityPool.Spawn(SpawnData spawnData)
        {
            return Spawn(spawnData);
        }

        EcsEntity IEntityPool.GetReadySpawnEntity()
        {
            return GetReadySpawnEntity();
        }

        void IEntityPool.Despawn(EcsEntity entity)
        {
            Despawn(entity);
        }

        #endregion
    }
}