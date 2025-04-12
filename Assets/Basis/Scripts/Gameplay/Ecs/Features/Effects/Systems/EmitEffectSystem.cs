using Basis.Gameplay.Ecs.Features.Effects.Components;
using BasisCore.VisualEffects;
using Leopotam.EcsLite;

namespace Basis.Gameplay.Ecs.Features.Effects.Systems
{
    public sealed class EmitEffectSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IEffectEmitter _effectEmitter;

        private EcsWorld _world;
        private EcsFilter _emmitEffectEventFilter;
        private EcsPool<EmitEffectEvent> _emitEffectEventPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _emmitEffectEventFilter = _world.Filter<EmitEffectEvent>().End();
            _emitEffectEventPool = _world.GetPool<EmitEffectEvent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var e in _emmitEffectEventFilter)
            {
                var emitEffectEvent = _emitEffectEventPool.Get(e);
                _effectEmitter.Emit(emitEffectEvent.EffectId, emitEffectEvent.Position, emitEffectEvent.Color);
            }
        }
    }
}