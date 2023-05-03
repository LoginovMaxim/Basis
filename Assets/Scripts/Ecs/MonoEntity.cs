using Leopotam.EcsLite;
using UnityEngine;

namespace Ecs
{
    public sealed class MonoEntity : MonoLinkBase
    {
        public EcsPackedEntityWithWorld Entity { get; private set; }

        public override void Make(ref EcsPackedEntityWithWorld entity)
        {
            Entity = entity;

            var monoLinks = GetComponents<MonoLinkBase>();
            foreach (var monoLink in monoLinks)
            {
                if (monoLink is MonoEntity)
                {
                    continue;
                }
                
                monoLink.Make(ref entity);
            }

            foreach (Transform child in transform)
            {
                monoLinks = child.GetComponentsInChildren<MonoLinkBase>();
                foreach (var monoLink in monoLinks)
                {
                    if (monoLink is MonoEntity)
                    {
                        continue;
                    }
                    
                    monoLink.Make(ref entity);
                }
            }
        }
    }
}
