using Leopotam.Ecs;

namespace Ecs
{
    public abstract class World : IWorld
    {
        private EcsWorld _world;

        public World()
        {
            _world = new EcsWorld();
        }

        #region IWorld

        EcsWorld IWorld.World => _world;

        #endregion
    }
}