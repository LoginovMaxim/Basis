using Leopotam.EcsLite;

namespace Ecs
{
    public abstract class World : IWorld
    {
        private EcsWorld _world;

        protected World()
        {
            _world = new EcsWorld();
        }

        #region IWorld

        EcsWorld IWorld.World => _world;

        #endregion
    }
}