using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Ecs
{
    public interface IEcsSetup
    {
        void Init(List<EcsOrderSystem> orderSystems, EcsSystems systems);
        void AddSystems();
        void AddInjects();
    }
}