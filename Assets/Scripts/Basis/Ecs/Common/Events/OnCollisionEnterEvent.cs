using UnityEngine;

namespace Basis.Ecs.Common.Events
{
    public struct OnCollisionEnterEvent
    {
        public Collision2D Collision;
        public GameObject Sender;
    }
}
