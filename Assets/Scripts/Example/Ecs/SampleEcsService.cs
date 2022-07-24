using App.Fsm;
using App.Monos;
using App.UI.Services;
using Ecs;
using Ecs.Common.Events;
using Ecs.Common.Systems;
using Example.Ecs.Events;
using Example.Ecs.Providers;
using Example.Ecs.Systems;
using VisualEffects;

namespace Example.Ecs
{
    public sealed class SampleEcsService : EcsService
    {
        private readonly IPrefabFactory _prefabFactory;
        private readonly IScreenService _screenService;
        private readonly IPopupService _popupService;
        private readonly IEffectEmitter _effectEmitter;
        private readonly IMapConfigProvider _mapConfigProvider;
        
        public SampleEcsService(
            IPrefabFactory prefabFactory,
            IScreenService screenService,
            IPopupService popupService,
            IEffectEmitter effectEmitter,
            IMapConfigProvider mapConfigProvider,
            IWorld world, 
            IMonoUpdater monoUpdater,
            UpdateType updateType) : 
            base(world, monoUpdater, updateType)
        {
            _prefabFactory = prefabFactory;
            _screenService = screenService;
            _popupService = popupService;
            _effectEmitter = effectEmitter;
            _mapConfigProvider = mapConfigProvider;
        }

        protected override void AddSystems()
        {
            AddSystem(-1000, new ConvertAllMonoEntitiesSystem(), true);
            AddSystem(1000, new SpawnSystem());
            AddSystem(1000, new EmitEffectSystem());
            AddSystem(0, new TimerSystem());
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new MapSystem());
        }

        protected override void AddOneFrameSystems()
        {
            AddOneFrameSystem<OnTriggerEnterEvent>();
            AddOneFrameSystem<OnTriggerStayEvent>();
            AddOneFrameSystem<OnEmitEffectRequested>();
            AddOneFrameSystem<OnMouseButtonDownEvent>();
            AddOneFrameSystem<OnMouseButtonUpEvent>();
            AddOneFrameSystem<OnKeyPressedEvent>();
        }

        protected override void AddSystemInjects()
        {
            AddSystemInject(_prefabFactory);
            AddSystemInject(_screenService);
            AddSystemInject(_popupService);
            AddSystemInject(_effectEmitter);
            AddSystemInject(_mapConfigProvider);
        }
    }
}