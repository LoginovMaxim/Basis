using Basis.Ecs.Pool;

namespace Basis.Example.Match.Pools.Ships
{
    public abstract class Ship : PoolObject, IShip
    {
        public override int Id => (int) ShipId;
        public ShipId ShipId { get; }
        
        protected Ship(ShipId shipId, int initialPoolSize) : base(initialPoolSize)
        {
            ShipId = shipId;
        }
    }
}