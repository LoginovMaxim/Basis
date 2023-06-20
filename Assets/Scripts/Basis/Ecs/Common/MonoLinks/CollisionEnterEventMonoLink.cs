using Basis.Ecs.Common.Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs.Common.MonoLinks
{
    public sealed class CollisionEnterEventMonoLink : PhysicMonoLinkBase
    {
        public void OnCollisionEnter2D(Collision2D other)
		{
			if (!Entity.Unpack(out var world, out var unpackedEntity))
			{
				return;
			}

			var pool = world.GetPool<OnCollisionEnterEvent>();
			ref var collisionEnterEvent = ref pool.Add(unpackedEntity);
			collisionEnterEvent = new OnCollisionEnterEvent
			{
				Collision = other,
				Sender = gameObject
			};
		}
	}
}
