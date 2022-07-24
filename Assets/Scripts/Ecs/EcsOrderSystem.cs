using Leopotam.Ecs;

namespace Ecs
{
    public struct EcsOrderSystem
    {
        public int Order;
        public IEcsSystem EcsSystem;
        public string SystemName;

        public EcsOrderSystem(int order, IEcsSystem ecsSystem, string systemName)
        {
            Order = order;
            EcsSystem = ecsSystem;
            SystemName = systemName;
        }
    }
}