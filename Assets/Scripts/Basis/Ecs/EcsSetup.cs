using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Basis.Ecs
{
    public abstract class EcsSetup : IEcsSetup
    {
        private List<EcsOrderSystem> _orderSystems;
        
        public void Init(List<EcsOrderSystem> orderSystems)
        {
            _orderSystems = orderSystems;
        }

        public abstract void AddSystems();
        
        protected void AddSystem(int order, IEcsSystem system)
        {
            CorrectOrderSystem(_orderSystems, ref order);
            _orderSystems.Add(new EcsOrderSystem(order, system));
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
    }
}