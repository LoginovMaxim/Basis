using App.UI.Services;
using Ecs;
using Ecs.Common.Events;
using Ecs.Common.Systems;
using Example.Match.Ecs.Events;
using Example.Match.Ecs.Systems;
using VisualEffects;

namespace Example.Match.Ecs
{
    public class SampleGameplayEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IPrefabFactory _prefabFactory;
        private readonly IPopupService _popupService;
        private readonly IEffectEmitter _effectEmitter;

        public SampleGameplayEcsSetup(IPrefabFactory prefabFactory, IPopupService popupService, IEffectEmitter effectEmitter)
        {
            _prefabFactory = prefabFactory;
            _popupService = popupService;
            _effectEmitter = effectEmitter;
        }

        protected override void AddSystems()
        {
#if UNITY_EDITOR
            AddSystem(-1000, new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            
            AddSystem(-1000, new ConvertAllMonoEntitiesSystem());
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new TimerSystem());
            AddSystem(500, new SpawnSystem());
            AddSystem(2000, new EmitEffectSystem());
            
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
        }
    }
}