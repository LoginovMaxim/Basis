using Basis.App.Pool;
using Basis.App.UI.Services;
using Basis.Ecs;
using Basis.Ecs.Common.Events;
using Basis.Ecs.Common.Systems;
using Basis.Example.Match.Ecs.Events;
using Basis.Example.Match.Ecs.Providers;
using Basis.Example.Match.Ecs.Systems;
using Basis.VisualEffects;

namespace Basis.Example.Match.Ecs.Setups
{
    public class SampleGameplayEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IEffectEmitter _effectEmitter;
        private readonly IShipPrefabConfigProvider _shipPrefabConfigProvider;
        private readonly IPoolService _poolService;

        public SampleGameplayEcsSetup(
            IEffectEmitter effectEmitter, 
            IShipPrefabConfigProvider shipPrefabConfigProvider,
            IPoolService poolService)
        {
            _effectEmitter = effectEmitter;
            _shipPrefabConfigProvider = shipPrefabConfigProvider;
            _poolService = poolService;
        }

        public override void AddSystems()
        {
#if UNITY_EDITOR
            AddSystem(-1000, new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            
            AddSystem(-1000, new InitShipPoolSystem());
            AddSystem(-1000, new SampleInputSystem());
            AddSystem(0, new TimerSystem());
            AddSystem(0, new SpawnShipSystem(_poolService));
            AddSystem(0, new DespawnShipSystem());
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
            AddInject(_effectEmitter);
            AddInject(_shipPrefabConfigProvider);
            AddInject(_poolService);
        }
    }
}