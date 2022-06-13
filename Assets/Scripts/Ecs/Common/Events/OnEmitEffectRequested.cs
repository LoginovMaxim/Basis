using UnityEngine;
using VisualEffects;

namespace Ecs.Common.Events
{
    public struct OnEmitEffectRequested
    {
        public EffectId EffectId;
        public Vector3 Position;
        public Color Color;
    }
}