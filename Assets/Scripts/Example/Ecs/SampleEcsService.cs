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
        private readonly IPopupService _popupService;
        private readonly IEffectEmitter _effectEmitter;
        private readonly IMapConfigProvider _mapConfigProvider;
        
        public SampleEcsService(
            IPrefabFactory prefabFactory,
            IPopupService popupService,
            IEffectEmitter effectEmitter,
            IMapConfigProvider mapConfigProvider,
            IWorld world, 
            IMonoUpdater monoUpdater,
            UpdateType updateType) : 
            base(world, monoUpdater, updateType)
        {
            _prefabFactory = prefabFactory;
            _popupService = popupService;
            _effectEmitter = effectEmitter;
            _mapConfigProvider = mapConfigProvider;
        }

        protected override void AddSystems()
        {
            AddSystem(-1000, new ConvertAllMonoEntitiesSystem());
            AddSystem(1000, new SpawnSystem());
            AddSystem(1000, new EmitEffectSystem());
            AddSystem(0, new TimerSystem());
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new MapSystem());
            
            AddSystem(10000, new OneFrameSystem<OnTriggerEnterEvent>());
            AddSystem(10000, new OneFrameSystem<OnTriggerStayEvent>());
            AddSystem(10000, new OneFrameSystem<OnEmitEffectRequested>());
            AddSystem(10000, new OneFrameSystem<OnMouseButtonDownEvent>());
            AddSystem(10000, new OneFrameSystem<OnMouseButtonUpEvent>());
            AddSystem(10000, new OneFrameSystem<OnKeyPressedEvent>());
        }

        protected override void AddInjects()
        {
            AddInject(_prefabFactory);
            AddInject(_popupService);
            AddInject(_effectEmitter);
            AddInject(_mapConfigProvider);
        }
    }
}