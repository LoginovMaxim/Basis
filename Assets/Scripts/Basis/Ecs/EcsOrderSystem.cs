using Leopotam.EcsLite;

namespace Basis.Ecs
{
    public struct EcsOrderSystem
    {
        public int Order;
        public IEcsSystem EcsSystem;

        public EcsOrderSystem(int order, IEcsSystem ecsSystem)
        {
            Order = order;
            EcsSystem = ecsSystem;
        }
    }
}