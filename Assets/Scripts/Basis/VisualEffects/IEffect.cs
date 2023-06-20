using UnityEngine;

namespace Basis.VisualEffects
{
    public interface IEffect
    {
        EffectId EffectId { get; }
        ParticleSystem ParticleSystem { get; }
    }
}