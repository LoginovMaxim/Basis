using Basis.Example.Match.Ecs.Configs;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Providers
{
    public interface IMapConfigProvider
    {
        GameObject CubePrefab { get; }
        int MapSize { get; }
        float OffsetSpeed { get; }
        float SmoothWave { get; }
        MapPerlinParameters[] MapPerlinParameters { get; }
    }
}