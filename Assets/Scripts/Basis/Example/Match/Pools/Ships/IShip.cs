using Basis.Ecs.Pool;

namespace Basis.Example.Match.Pools.Ships
{
    public interface IShip : IPoolObject
    {
        ShipId ShipId { get; }
    }
}