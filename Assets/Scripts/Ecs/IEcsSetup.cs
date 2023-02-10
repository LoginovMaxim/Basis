using System.Collections.Generic;
using Leopotam.Ecs;

namespace Ecs
{
    public interface IEcsSetup
    {
        void Init(List<EcsOrderSystem> orderSystems, EcsSystems systems);
        void AddSystems();
        void AddOneFrameSystems();
        void AddSystemInjects();
    }
}