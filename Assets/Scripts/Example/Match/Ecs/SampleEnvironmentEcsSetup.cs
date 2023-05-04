using Ecs;
using Example.Match.Ecs.Providers;
using Example.Match.Ecs.Systems;

namespace Example.Match.Ecs
{
    public sealed class SampleEnvironmentEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IMapConfigProvider _mapConfigProvider;

        public SampleEnvironmentEcsSetup(IMapConfigProvider mapConfigProvider)
        {
            _mapConfigProvider = mapConfigProvider;
        }

        protected override void AddSystems()
        {
            AddSystem(0, new MapSystem());
        }

        protected override void AddInjects()
        {
            AddInject(_mapConfigProvider);
        }
    }
}