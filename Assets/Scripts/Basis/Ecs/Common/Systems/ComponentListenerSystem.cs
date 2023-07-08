using System.Collections.Generic;
using System.Linq;
using Leopotam.EcsLite;

namespace Basis.Ecs.Common.Systems
{
    public sealed class ComponentListenerSystem<TComponent> : IEcsInitSystem, IEcsRunSystem where TComponent : struct
    {
        private readonly IComponentObserver<TComponent> _componentObserver;
        
        private EcsFilter _filter;
        private EcsPool<TComponent> _pool;
        private Dictionary<int, ComponentInfo> _componentInfosByEntities;

        public ComponentListenerSystem(IComponentObserver<TComponent> componentObserver)
        {
            _componentObserver = componentObserver;
            _componentInfosByEntities = new Dictionary<int, ComponentInfo>();
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.Filter<TComponent>().End();
            _pool = world.GetPool<TComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var component = _pool.Get(entity);

                CheckAddComponent(entity, component);
                CheckChangeComponent(entity, component);

                _componentInfosByEntities[entity].Present = true;
            }

            CheckRemoveComponent();
        }

        private void CheckAddComponent(int entity, TComponent component)
        {
            if (_componentInfosByEntities.Any(componentInfo => componentInfo.Key == entity))
            {
                return;
            }
            
            _componentInfosByEntities.Add(entity, new ComponentInfo(component, true));
            _componentObserver.OnComponentAdded(entity, component);
        }

        private void CheckChangeComponent(int entity, TComponent component)
        {
            if (!_componentInfosByEntities.TryGetValue(entity, out var componentInfo))
            {
                return;
            }

            if (component.Equals(componentInfo.Component))
            {
                return;
            }
            
            _componentObserver.OnComponentChanged(entity, componentInfo.Component, component);
            _componentInfosByEntities[entity].Component = component;
        }

        private void CheckRemoveComponent()
        {
            var removeComponentEntities = new List<int>();
            foreach (var componentInfoByEntity in _componentInfosByEntities)
            {
                var entity = componentInfoByEntity.Key;
                var componentInfo = componentInfoByEntity.Value;

                if (componentInfo.Present)
                {
                    componentInfo.Present = false;
                    continue;
                }

                removeComponentEntities.Add(entity);
            }

            foreach (var removeComponentEntity in removeComponentEntities)
            {
                var component = _componentInfosByEntities[removeComponentEntity].Component;
                _componentInfosByEntities.Remove(removeComponentEntity);
                _componentObserver.OnComponentRemoved(removeComponentEntity, component);
            }
        }

        private class ComponentInfo
        {
            public TComponent Component { get; set; }
            public bool Present { get; set; }

            public ComponentInfo(TComponent component, bool present)
            {
                Component = component;
                Present = present;
            }
        }
    }
}