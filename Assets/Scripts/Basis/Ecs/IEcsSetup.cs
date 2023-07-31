using System.Collections.Generic;

namespace Basis.Ecs
{
    public interface IEcsSetup
    {
        void Init(List<EcsOrderSystem> orderSystems);
        void AddSystems();
    }
}