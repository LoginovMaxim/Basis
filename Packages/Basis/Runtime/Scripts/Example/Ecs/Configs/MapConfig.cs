﻿using Example.Ecs.Providers;
using UnityEngine;

namespace Example.Ecs.Configs
{
    [CreateAssetMenu(menuName = "Example/Config/MapConfig", fileName = "MapConfig")]
    public sealed class MapConfig : ScriptableObject, IMapConfigProvider
    {
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private int _mapSize;
        [SerializeField] private float _offsetSpeed;
        [SerializeField] private MapPerlinParameters[] _mapPerlinParameters;
        
        #region IMapConfigProvider

        GameObject IMapConfigProvider.CubePrefab => _cubePrefab;
        int IMapConfigProvider.MapSize => _mapSize;
        float IMapConfigProvider.OffsetSpeed => _offsetSpeed;
        MapPerlinParameters[] IMapConfigProvider.MapPerlinParameters => _mapPerlinParameters;

        #endregion
    }
}