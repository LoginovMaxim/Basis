using Example.Match.Pools.Ships;
using UnityEngine;

namespace Example.Match.Ecs.Providers
{
    public interface IShipPrefabConfigProvider
    {
        GameObject GetShipPrefabById(ShipId shipId);
    }
}