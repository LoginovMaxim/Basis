using Ecs;
using Example.Match.Ecs.Providers;
using Example.Match.Ecs.Systems;
using Example.Match.Pools.Ships;

namespace Example.Match.Ecs
{
    public sealed class SampleEnvironmentEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IMapConfigProvider _mapConfigProvider;
        private readonly IShipPool _shipPool;

        public SampleEnvironmentEcsSetup(IMapConfigProvider mapConfigProvider, IShipPool shipPool)
        {
            _mapConfigProvider = mapConfigProvider;
            _shipPool = shipPool;
        }

        protected override void AddSystems()
        {
            AddSystem(-100, new MapBuilderSystem());
            AddSystem(1000, new MapUpdateSystem());
        }

        protected override void AddInjects()
        {
            AddInject(_mapConfigProvider);
            AddInject(_shipPool);
        }
    }
}