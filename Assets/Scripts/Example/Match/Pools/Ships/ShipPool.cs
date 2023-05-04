using System.Collections.Generic;
using Ecs.Pool;

namespace Example.Match.Pools.Ships
{
    public sealed class ShipPool : Pool<IShip>, IShipPool
    {
        public ShipPool(List<IEntityPool> entityPool) : base(entityPool)
        {
        }
    }
}