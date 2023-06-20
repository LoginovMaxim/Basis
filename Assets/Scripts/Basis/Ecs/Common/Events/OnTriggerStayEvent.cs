using UnityEngine;

namespace Basis.Ecs.Common.Events
{
    public struct OnTriggerStayEvent
    {
        public Collider2D Collider;
        public GameObject Sender;
    }
}