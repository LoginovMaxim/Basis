using Ecs;
using Example.Ecs.Providers;
using Example.Ecs.Systems;

namespace Example.Ecs
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