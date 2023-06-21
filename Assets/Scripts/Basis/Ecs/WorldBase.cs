using Leopotam.EcsLite;

namespace Basis.Ecs
{
    public abstract class WorldBase : IWorld
    {
        public EcsWorld World { get; private set; }

        protected WorldBase()
        {
            World = new EcsWorld();
        }
    }
}