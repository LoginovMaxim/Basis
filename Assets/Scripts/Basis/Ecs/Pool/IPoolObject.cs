namespace Basis.Ecs.Pool
{
    public interface IPoolObject
    {
        public int Id { get; }
        public int InitialPoolSize { get; }
    }
}