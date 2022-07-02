using App.Monos;
using Ecs;
using Example.Ecs.Events;
using Example.Ecs.Providers;
using Example.Ecs.Systems;
using Zenject;

namespace Example.Ecs
{
    public sealed class SampleEcsWorldService : BaseEcsWorldService
    {
        [Inject] private readonly IMapConfigProvider _mapConfigProvider;
        
        public SampleEcsWorldService(IMonoUpdater monoUpdater) : base(monoUpdater)
        {
        }

        protected override void AddSystems()
        {
            base.AddSystems();
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new MapSystem());
        }

        protected override void AddInjectSystems()
        {
            base.AddInjectSystems();
            Systems
                .Inject(_mapConfigProvider);
        }

        protected override void AddOneFramesToSystems()
        {
            base.AddOneFramesToSystems();
            Systems
                .OneFrame<OnKeyPressedEvent>();
        }
    }
}