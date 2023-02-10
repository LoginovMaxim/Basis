using System.Collections.Generic;
using Leopotam.Ecs;
using Utils;

namespace Ecs
{
    public abstract class EcsSetup : IEcsSetup
    {
        private List<EcsOrderSystem> _orderSystems;
        private EcsSystems _systems;
        
        private void Init(List<EcsOrderSystem> orderSystems, EcsSystems systems)
        {
            _orderSystems = orderSystems;
            _systems = systems;
        }

        protected abstract void AddSystems();

        protected abstract void AddOneFrameSystems();

        protected abstract void AddSystemInjects();
        
        protected void AddSystem(int order, IEcsSystem system, bool isOnlyInitSystem = false)
        {
            CorrectOrderSystem(_orderSystems, ref order);
            var systemName = !isOnlyInitSystem ? TypeUtils.GetConcreteTypeName($"{system.GetType()}") : string.Empty;
            _orderSystems.Add(new EcsOrderSystem(order, system, systemName));
        }
        
        protected void AddOneFrameSystem<T>() where T: struct
        {
            _systems.OneFrame<T>();
        }

        protected void AddSystemInject(object injectObject)
        {
            _systems.Inject(injectObject);
        }

        private void CorrectOrderSystem(List<EcsOrderSystem> systems, ref int order)
        {
            for (var i = 0; i < systems.Count; i++)
            {
                if (systems[i].Order != order)
                {
                    continue;
                }

                order++;
            }
        }

        #region IEcsSetup
        
        void IEcsSetup.Init(List<EcsOrderSystem> orderSystems, EcsSystems systems)
        {
            Init(orderSystems, systems);
        }

        void IEcsSetup.AddSystems()
        {
            AddSystems();
        }

        void IEcsSetup.AddOneFrameSystems()
        {
            AddOneFrameSystems();
        }

        void IEcsSetup.AddSystemInjects()
        {
            AddSystemInjects();
        }

        #endregion
    }
}