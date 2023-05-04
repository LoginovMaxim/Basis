using Example.Match.Ecs.Configs;
using UnityEngine;

namespace Example.Match.Ecs.Providers
{
    public interface IMapConfigProvider
    {
        GameObject CubePrefab { get; }
        int MapSize { get; }
        float OffsetSpeed { get; }
        MapPerlinParameters[] MapPerlinParameters { get; }
    }
}