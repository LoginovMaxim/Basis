using Ecs.Common.Components;
using Example.Ecs.Components;
using Example.Ecs.Events;
using Example.Ecs.Providers;
using Leopotam.Ecs;
using UnityEngine;

namespace Example.Ecs.Systems
{
    public sealed class MapSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<OnKeyPressedEvent> _keyPressedFilter = null;
        private readonly EcsFilter<CubeTagComponent> _cubeFilter = null;

        private readonly IMapConfigProvider _mapConfigProvider;
        
        private Vector2 _offset;

        public void Init()
        {
            for (var i = 0; i < _mapConfigProvider.MapSize; i++)
            {
                for (var j = 0; j < _mapConfigProvider.MapSize; j++)
                {
                    _world.NewEntity().Get<SpawnComponent>() = new SpawnComponent
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
        
        public void Run()
        {
            foreach (var k in _keyPressedFilter)
            {
                ref var keyPressedComponent = ref _keyPressedFilter.Get1(k);

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

            foreach (var c in _cubeFilter)
            {
                ref var cubeEntity = ref _cubeFilter.GetEntity(c);
                ref var cubeTransform = ref cubeEntity.Get<TransformComponent>().Transform;
                
                var perlinX = cubeTransform.position.x / _mapConfigProvider.MapSize + _offset.x;
                var perlinY = cubeTransform.position.z / _mapConfigProvider.MapSize + _offset.y;
                
                var scale = 0f;
                for (var i = 0; i < _mapConfigProvider.MapPerlinParameters.Length; i++)
                {
                    var amplitude = _mapConfigProvider.MapPerlinParameters[i].Amplitude;
                    var frequency = _mapConfigProvider.MapPerlinParameters[i].Frequency;
                    scale += amplitude * Mathf.PerlinNoise(frequency * perlinX, frequency * perlinY);
                }
                
                var cubeScale = cubeTransform.localScale;
                cubeScale.y = scale;
                
                cubeTransform.localScale = cubeScale;
            }
        }
    }
}