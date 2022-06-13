using Ecs.Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Common.MonoLinks
{
    public sealed class RigidbodyMonoLink : MonoLink<RigidbodyComponent>
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<RigidbodyComponent>() = new RigidbodyComponent
            {
                Rigidbody = _rigidbody
            };
        }
    }
}
