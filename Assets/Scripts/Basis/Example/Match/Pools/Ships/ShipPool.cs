using System.Collections.Generic;
using Basis.Ecs.Pool;

namespace Basis.Example.Match.Pools.Ships
{
    public sealed class ShipPool : Pool<IShip>, IShipPool
    {
        public ShipPool(List<IEntityPool> entityPool) : base(entityPool)
        {
        }
    }
}