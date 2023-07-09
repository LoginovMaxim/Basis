using System;
using System.Collections.Generic;
using Basis.Utils;
using Basis.Views;
using Leopotam.EcsLite;
using Project.Match.Ecs;
using Project.Match.Ecs.Features.View.Components;
using UnityEngine;

namespace Basis.Pool
{
    public sealed class PoolService : IPoolService
    { 
        private readonly IViewsProvider _viewsProvider;

        private Dictionary<Type, IViewPool> _viewPoolsByTypes = new Dictionary<Type, IViewPool>();
        private EcsPool<ActiveTag> _activeTagPool;

        public PoolService(IViewsProvider viewsProvider, IMatchEcsWorld matchEcsWorld)
        {
            _viewsProvider = viewsProvider;
            _activeTagPool = matchEcsWorld.World.GetPool<ActiveTag>();
        }

        public bool TryAddViewPool(Type viewObjectType, IViewPool viewPool)
        {
            if (_viewPoolsByTypes.ContainsKey(viewObjectType))
            {
                Debug.Log($"View in type [{viewObjectType}] has already been added to the PoolService"
                    .WithColor(LoggerColor.Orange));
                return false;
            }
            
            _viewPoolsByTypes.Add(viewObjectType, viewPool);
            return true;
        }

        public bool TryRemoveViewPool(Type viewObjectType)
        {
            if (!_viewPoolsByTypes.ContainsKey(viewObjectType))
            {
                Debug.Log($"Missing ViewPool for [{viewObjectType}] view object type".WithColor(LoggerColor.Orange));
                return false;
            }
            
            _viewPoolsByTypes.Remove(viewObjectType);
            return true;
        }

        public bool TrySpawnView<TViewObjectType>(int entityId) where TViewObjectType : IViewObject
        {
            return TrySpawnView<TViewObjectType>(entityId, out _);
        }

        public bool TrySpawnView<TViewObjectType>(int entityId, out IViewObject viewObject) where TViewObjectType : IViewObject
        {
            viewObject = default;
            if (!_viewPoolsByTypes.TryGetValue(typeof(TViewObjectType), out var viewPool))
            {
                Debug.Log($"Missing ViewPool for Spawn [{typeof(TViewObjectType)}] view".WithColor(LoggerColor.Orange));
                return false;
            }

            viewObject = viewPool.Spawn();
            _viewsProvider.TryAdd(entityId, viewObject);
            _activeTagPool.Add(entityId);
            return true;
        }

        public bool TryDespawnView(int entityId)
        {
            if (!_viewsProvider.TryGet(entityId, out var viewObject))
            {
                return false;
            }

            if (!_viewPoolsByTypes.ContainsKey(viewObject.GetType()))
            {
                Debug.Log($"Missing ViewObject type [{viewObject.GetType()}] in PoolService".WithColor(LoggerColor.Orange));
                return false;
            }
            
            if (!_viewPoolsByTypes.TryGetValue(viewObject.GetType(), out var viewPool))
            {
                Debug.Log($"Missing ViewPool for [{viewObject.GetType()}] ViewObject type".WithColor(LoggerColor.Orange));
                return false;
            }

            viewPool.Despawn(viewObject);
            _viewsProvider.TryRemove(entityId);
            _activeTagPool.Del(entityId);
            return true;
        }
    }
}