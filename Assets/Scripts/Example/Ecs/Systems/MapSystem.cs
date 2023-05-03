using Ecs.Common.Components;
using Example.Ecs.Components;
using Example.Ecs.Events;
using Example.Ecs.Providers;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Example.Ecs.Systems
{
    public sealed class MapSystem : IEcsInitSystem, IEcsRunSystem
    {
        [EcsInject] private readonly IMapConfigProvider _mapConfigProvider;
        
        private Vector2 _offset;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var spawns = world.GetPool<SpawnComponent>();
            
            for (var i = 0; i < _mapConfigProvider.MapSize; i++)
            {
                for (var j = 0; j < _mapConfigProvider.MapSize; j++)
                {
                    var entity = world.NewEntity();
                    ref var spawn = ref spawns.Add(entity);
                    spawn = new SpawnComponent
                    {
                        Prefab = _mapConfigProvider.CubePrefab,
                        Position = new Vector3(i, 0, j),
                        Rotation = Quaternion.identity,
                        Scale = Vector3.one,
                        Parent = null
                    };
                }
            }
        }

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var keyPressedFilter = world.Filter<OnKeyPressedEvent>().End();
            var keyPressedEvents = world.GetPool<OnKeyPressedEvent>();
            
            foreach (var keyPressedEntity in keyPressedFilter)
            {
                ref var keyPressedComponent = ref keyPressedEvents.Get(keyPressedEntity);
                switch (keyPressedComponent.KeyCode)
                {
                    case KeyCode.W:
                    {
                        _offset.y += Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    }
                    case KeyCode.S:
                    {
                        _offset.y -= Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    }
                    case KeyCode.A:
                    {
                        _offset.x -= Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    }
                    case KeyCode.D:
                    {
                        _offset.x += Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    }
                }
            }
            
            var cubeTagFilter = world.Filter<CubeTagComponent>().End();
            var transforms = world.GetPool<TransformComponent>();

            foreach (var cubeEntity in cubeTagFilter)
            {
                ref var transform = ref transforms.Get(cubeEntity).Transform;
                
                var perlinX = transform.position.x / _mapConfigProvider.MapSize + _offset.x;
                var perlinY = transform.position.z / _mapConfigProvider.MapSize + _offset.y;
                
                var scale = 0f;
                for (var i = 0; i < _mapConfigProvider.MapPerlinParameters.Length; i++)
                {
                    var amplitude = _mapConfigProvider.MapPerlinParameters[i].Amplitude;
                    var frequency = _mapConfigProvider.MapPerlinParameters[i].Frequency;
                    scale += amplitude * Mathf.PerlinNoise(frequency * perlinX, frequency * perlinY);
                }
                
                var cubeScale = transform.localScale;
                cubeScale.y = scale;
                
                transform.localScale = cubeScale;
            }
        }
    }
}