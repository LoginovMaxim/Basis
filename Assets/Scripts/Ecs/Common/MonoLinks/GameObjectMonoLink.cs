using Ecs.Common.Components;
using Leopotam.Ecs;

namespace Ecs.Common.MonoLinks
{
    public sealed class GameObjectMonoLink : MonoLink<GameObjectComponent>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<GameObjectComponent>() = new GameObjectComponent
            {
                GameObject = gameObject
            };
        }
    }
}
