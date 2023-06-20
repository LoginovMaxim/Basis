using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsPackedEntityWithWorld entity);
    }
}
