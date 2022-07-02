using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Common.MonoLinks
{
    public sealed class TransformMonoLink : MonoLink<TransformComponent>
    {
        [SerializeField] private Transform _transform;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<TransformComponent>() = new TransformComponent
            {
                Transform = _transform
            };
        }
    }
}
