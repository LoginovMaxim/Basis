using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Pool
{
    public abstract class Pool<TPoolObject> : IPool where TPoolObject : IPoolObject
    {
        public List<IEntityPool> EntityPool { get; }

        protected Pool(List<IEntityPool> entityPool)
        {
            EntityPool = entityPool;
        }

        public EcsPackedEntityWithWorld Spawn(int id, SpawnData spawnData)
        {
            foreach (var pool in EntityPool)
            {
                if (pool.PoolObject is not TPoolObject poolObject)
                {
                    continue;
                }
                
                if (poolObject.Id != id)
                {
                    continue;
                }

                return pool.Spawn(spawnData);
            }

            Debug.LogError($"Missing pool object for id {id}");
            return default;
        }

        public void Despawn(int id, EcsPackedEntityWithWorld entity)
        {
            foreach (var pool in EntityPool)
            {
                if (pool.PoolObject is not TPoolObject poolObject)
                {
                    continue;
                }
                
                if (poolObject.Id != id)
                {
                    continue;
                }

                pool.Despawn(entity);
                return;
            }
            
            Debug.LogError($"Can't despawn {entity} entity");
        }
    }
}