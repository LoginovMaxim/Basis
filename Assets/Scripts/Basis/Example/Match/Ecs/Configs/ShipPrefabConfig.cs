using System;
using System.Collections.Generic;
using Basis.Example.Match.Ecs.Providers;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Configs
{
    [CreateAssetMenu(menuName = "Example/Config/ShipPrefabs", fileName = "ShipPrefabs")]
    public sealed class ShipPrefabConfig : ScriptableObject, IShipPrefabConfigProvider
    {
        [SerializeField] private List<ShipPrefabData> _shipPrefabData;

        /*public GameObject GetShipPrefabById(ShipId shipId)
        {
            foreach (var shipPrefabData in _shipPrefabData)
            {
                if (shipPrefabData.ShipId != shipId)
                {
                    continue;
                }

                return shipPrefabData.Prefab;
            }

            throw new Exception($"Missing ship prefab with {shipId} ship id");
        }*/
    }

    [Serializable] public struct ShipPrefabData
    {
        //public ShipId ShipId;
        public GameObject Prefab;
    }
}