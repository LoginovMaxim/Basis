using Leopotam.Ecs;

namespace Ecs
{
    public struct EcsSystemData
    {
        public int Order;
        public IEcsSystem EcsSystem;
        public string SystemName;

        public EcsSystemData(int order, IEcsSystem ecsSystem, string systemName)
        {
            Order = order;
            EcsSystem = ecsSystem;
            SystemName = systemName;
        }
    }
}