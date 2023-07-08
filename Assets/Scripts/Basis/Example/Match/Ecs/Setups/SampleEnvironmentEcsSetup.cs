using Basis.App.Pool;
using Basis.Ecs;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Ecs.Systems;

namespace Basis.Example.Match.Ecs.Setups
{
    public sealed class SampleEnvironmentEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IMapConfigProvider _mapConfigProvider;
        private readonly IPoolService _poolService;

        public SampleEnvironmentEcsSetup(IMapConfigProvider mapConfigProvider, IPoolService poolService)
        {
            _mapConfigProvider = mapConfigProvider;
            _poolService = poolService;
        }

        public override void AddSystems()
        {
            AddSystem(-100, new MapBuilderSystem(_mapConfigProvider, _poolService));
            AddSystem(1000, new MapUpdateSystem(_mapConfigProvider));
        }

        public override void AddInjects()
        {
        }
    }
}