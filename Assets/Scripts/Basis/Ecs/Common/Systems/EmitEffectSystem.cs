using Basis.Ecs.Common.Events;
using Basis.VisualEffects;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Ecs.Common.Systems
{
    public sealed class EmitEffectSystem : IEcsRunSystem
    {
        [EcsInject] private readonly IEffectEmitter _effectEmitter;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var emitEffectFilter = world.Filter<OnEmitEffectRequested>().End();
            var emitEffectRequests = world.GetPool<OnEmitEffectRequested>();
            
            foreach (var entity in emitEffectFilter)
            {
                ref var emitEffect = ref emitEffectRequests.Get(entity);
                //_effectEmitter.Emit(emitEffect.EffectId, emitEffect.Position);
            }
        }
    }
}