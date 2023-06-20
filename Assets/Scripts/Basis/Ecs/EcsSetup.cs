using System.Collections.Generic;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Ecs
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
        protected abstract void AddInjects();
        
        protected void AddSystem(int order, IEcsSystem system)
        {
            CorrectOrderSystem(_orderSystems, ref order);
            _orderSystems.Add(new EcsOrderSystem(order, system));
        }

        protected void AddInject<T>(T shared) where T : class
        {
            _systems.InjectShared(shared);
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

        void IEcsSetup.AddInjects()
        {
            AddInjects();
        }

        #endregion
    }
}