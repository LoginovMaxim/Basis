using Basis.Ecs;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Ecs.Systems;
using Basis.Example.Match.Pools.Ships;

namespace Basis.Example.Match.Ecs
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

        public override void AddSystems()
        {
            AddSystem(-100, new MapBuilderSystem());
            AddSystem(1000, new MapUpdateSystem());
        }

        public override void AddInjects()
        {
            AddInject(_mapConfigProvider);
            AddInject(_shipPool);
        }
    }
}