using Ecs.Common.Events;
using Leopotam.Ecs;
using VisualEffects;

namespace Ecs.Common.Systems
{
    public sealed class EmitEffectSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<OnEmitEffectRequested> _filter = null;

        private IEffectEmitter _effectEmitter;
        
        public void Run()
        {
            foreach (var e in _filter)
            {
                ref var emitEffect = ref _filter.Get1(e);
                _effectEmitter.Emit(emitEffect.EffectId, emitEffect.Position, emitEffect.Color);
            }
        }
    }
}