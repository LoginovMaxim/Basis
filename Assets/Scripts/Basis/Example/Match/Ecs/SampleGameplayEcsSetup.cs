using Basis.App.UI.Services;
using Basis.Ecs;
using Basis.Ecs.Common.Events;
using Basis.Ecs.Common.Systems;
using Basis.Example.Match.Ecs.Events;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Ecs.Systems;
using Basis.Example.Match.Pools.Ships;
using Basis.VisualEffects;

namespace Basis.Example.Match.Ecs
{
    public class SampleGameplayEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IPrefabFactory _prefabFactory;
        private readonly IPopupService _popupService;
        private readonly IEffectEmitter _effectEmitter;
        private readonly IShipPrefabConfigProvider _shipPrefabConfigProvider;
        private readonly IShipPool _unitPool;

        public SampleGameplayEcsSetup(
            IPrefabFactory prefabFactory, 
            IPopupService popupService, 
            IEffectEmitter effectEmitter, 
            IShipPrefabConfigProvider shipPrefabConfigProvider, 
            IShipPool unitPool)
        {
            _prefabFactory = prefabFactory;
            _popupService = popupService;
            _effectEmitter = effectEmitter;
            _shipPrefabConfigProvider = shipPrefabConfigProvider;
            _unitPool = unitPool;
        }

        public override void AddSystems()
        {
#if UNITY_EDITOR
            AddSystem(-1000, new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            
            AddSystem(-1000, new ConvertAllMonoEntitiesSystem());
            AddSystem(-1000, new InitShipPoolSystem());
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new TimerSystem());
            AddSystem(0, new SpawnShipSystem());
            AddSystem(0, new DespawnShipSystem());
            AddSystem(500, new SpawnSystem());
            AddSystem(2000, new EmitEffectSystem());
            
            AddSystem(10000, new OneFrameSystem<OnTriggerEnterEvent>());
            AddSystem(10000, new OneFrameSystem<OnTriggerStayEvent>());
            AddSystem(10000, new OneFrameSystem<OnEmitEffectRequested>());
            AddSystem(10000, new OneFrameSystem<OnMouseButtonDownEvent>());
            AddSystem(10000, new OneFrameSystem<OnMouseButtonUpEvent>());
            AddSystem(10000, new OneFrameSystem<OnKeyPressedEvent>());
        }

        public override void AddInjects()
        {
            AddInject(_prefabFactory);
            AddInject(_popupService);
            AddInject(_effectEmitter);
            AddInject(_shipPrefabConfigProvider);
            AddInject(_unitPool);
        }
    }
}