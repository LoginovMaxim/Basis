using Basis.Example.Match.Pools.Ships;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Providers
{
    public interface IShipPrefabConfigProvider
    {
        GameObject GetShipPrefabById(ShipId shipId);
    }
}