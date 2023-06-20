namespace Basis.Ecs.Pool
{
    public abstract class PoolObject : IPoolObject
    {
        public abstract int Id { get; }
        public int InitialPoolSize { get; }

        protected PoolObject(int initialPoolSize)
        {
            InitialPoolSize = initialPoolSize;
        }
    }
}