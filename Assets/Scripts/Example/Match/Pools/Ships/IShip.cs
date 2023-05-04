using Ecs;
using Ecs.Pool;

namespace Example.Match.Pools.Ships
{
    public interface IShip : IPoolObject
    {
        ShipId ShipId { get; }
    }
}