using Basis.Ecs;
using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Components;
using Basis.Example.Match.Ecs.Events;
using Basis.Example.Match.Ecs.Providers;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class MapUpdateSystem : IEcsRunSystem
    {
        [EcsInject] private readonly IMapConfigProvider _mapConfigProvider;
        [EcsInject] private readonly IPrefabFactory _prefabFactory;
        
        private Vector2 _offset;

        public void Run(IEcsSystems systems)
        {
            if (TryUpdateOffset(systems))
            {
                UpdateMap(systems);
            }
        }

        private bool TryUpdateOffset(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var keyPressedFilter = world.Filter<OnKeyPressedEvent>().End();
            if (keyPressedFilter.GetEntitiesCount() == 0)
            {
                return false;
            }
            
            var keyPressedEvents = world.GetPool<OnKeyPressedEvent>();
            
            foreach (var keyPressedEntity in keyPressedFilter)
            {
                ref var keyPressedComponent = ref keyPressedEvents.Get(keyPressedEntity);
                switch (keyPressedComponent.KeyCode)
                {
                    case KeyCode.W:
                        _offset.y += Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    case KeyCode.S:
                        _offset.y -= Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    case KeyCode.A:
                        _offset.x -= Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                    case KeyCode.D:
                        _offset.x += Time.deltaTime * _mapConfigProvider.OffsetSpeed;
                        break;
                }
            }
            
            return true;
        }

        private void UpdateMap(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var cubeTagFilter = world.Filter<CubeTagComponent>().End();
            if (cubeTagFilter.GetEntitiesCount() == 0)
            {
                return;
            }
            
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
                
                transform.localScale = 
                    Vector3.Lerp(transform.localScale, cubeScale, _mapConfigProvider.SmoothWave * Time.deltaTime);
            }
        }
    }
}