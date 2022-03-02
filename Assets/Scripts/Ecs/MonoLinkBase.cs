using Leopotam.Ecs;
using UnityEngine;

namespace CoreECS
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsEntity entity);
    }
}
