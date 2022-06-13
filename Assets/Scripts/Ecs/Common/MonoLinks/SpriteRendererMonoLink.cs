using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Common.MonoLinks
{
    public sealed class SpriteRendererMonoLink : MonoLink<SpriteRendererComponent>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<SpriteRendererComponent>() = new SpriteRendererComponent
            {
                SpriteRenderer = _spriteRenderer
            };
        }
    }
}