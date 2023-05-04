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
            AddSystem(-100, new MapBuilderSystem());
            AddSystem(1000, new MapUpdateSystem());
        }

        protected override void AddInjects()
        {
            AddInject(_mapConfigProvider);
        }
    }
}