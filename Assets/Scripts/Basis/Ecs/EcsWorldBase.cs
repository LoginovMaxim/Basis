using Leopotam.EcsLite;

namespace Basis.Ecs
{
    public abstract class EcsWorldBase : IEcsWorld
    {
        public EcsWorld World { get; }

        protected EcsWorldBase()
        {
            World = new EcsWorld();
        }
    }
}