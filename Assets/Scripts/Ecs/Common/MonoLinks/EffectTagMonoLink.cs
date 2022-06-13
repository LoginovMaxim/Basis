using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;
using VisualEffects;

namespace Ecs.Common.MonoLinks
{
    public sealed class EffectTagMonoLink : MonoLink<EffectTagComponent>
    {
        [SerializeField] private EffectId _effectId;
        
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<EffectTagComponent>() = new EffectTagComponent
            {
                EffectId = _effectId
            };
        }
    }
}