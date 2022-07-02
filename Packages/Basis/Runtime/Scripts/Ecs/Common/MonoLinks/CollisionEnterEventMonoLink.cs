using Ecs.Common.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Common.MonoLinks
{
    public sealed class CollisionEnterEventMonoLink : PhysicMonoLinkBase
    {
        public void OnCollisionEnter2D(Collision2D other)
		{
			Entity.Get<OnCollisionEnterEvent>() = new OnCollisionEnterEvent
			{
				Collision = other,
				Sender = gameObject
			};
		}
	}
}
