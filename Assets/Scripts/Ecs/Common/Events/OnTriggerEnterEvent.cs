using UnityEngine;

namespace Ecs.Common.Events
{
    public struct OnTriggerEnterEvent
    {
        public Collider2D Collider;
        public GameObject Sender;
    }
}
