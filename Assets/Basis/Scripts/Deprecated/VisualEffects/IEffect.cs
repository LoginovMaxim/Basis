using UnityEngine;

namespace Basis.Deprecated.VisualEffects
{
    public interface IEffect
    {
        EffectId EffectId { get; }
        ParticleSystem ParticleSystem { get; }
    }
}