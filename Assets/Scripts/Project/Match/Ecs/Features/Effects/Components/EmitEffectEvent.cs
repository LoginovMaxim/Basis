using Basis.VisualEffects;
using UnityEngine;

namespace Project.Match.Ecs.Features.Effects.Components
{
    public struct EmitEffectEvent
    {
        public EffectId EffectId;
        public Vector3 Position;
        public Color Color;
    }
}