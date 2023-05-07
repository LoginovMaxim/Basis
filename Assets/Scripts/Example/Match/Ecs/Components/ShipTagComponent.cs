using System;
using Example.Match.Pools.Ships;

namespace Example.Match.Ecs.Components
{
    [Serializable]
    public struct ShipTagComponent
    {
        public ShipId ShipId;
    }
}