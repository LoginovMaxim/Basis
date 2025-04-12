using BasisCore.VisualEffects;
using UnityEngine;

namespace Basis.Gameplay.Ecs.Features.Effects.Components
{
    public struct EmitEffectEvent
    {
        public EffectId EffectId;
        public Vector3 Position;
        public Color Color;
    }
}