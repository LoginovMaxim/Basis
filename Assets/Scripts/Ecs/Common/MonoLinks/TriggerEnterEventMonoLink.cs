using Ecs.Common.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Common.MonoLinks
{
    public sealed class TriggerEnterEventMonoLink : PhysicMonoLinkBase
    {
        private void OnTriggerEnter2D(Collider2D collision)
		{
			Entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent
			{
				Collider = collision,
				Sender = gameObject
			};
		}
        
        private void OnTriggerStay2D(Collider2D collision)
        {
	        Entity.Get<OnTriggerStayEvent>() = new OnTriggerStayEvent
	        {
		        Collider = collision,
		        Sender = gameObject
	        };
        }
	}
}
