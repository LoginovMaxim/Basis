using Basis.Ecs;
using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Components;
using Basis.Example.Match.Ecs.Events;
using Basis.Example.Match.Ecs.Providers;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class MapUpdateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IMapConfigProvider _mapConfigProvider;

        private EcsWorld _world;
        private EcsFilter _onKeyPressedEventFilter;
        private EcsFilter _seaBlockTagFilter;
        private EcsPool<OnKeyPressedEvent> _onKeyPressedEventPool;
        private EcsPool<PositionSmooth> _positionPool;
        private EcsPool<ScaleSmooth> _scalePool;
        private Vector2 _offset;

        public MapUpdateSystem(IMapConfigProvider mapConfigProvider)
        {
            _mapConfigProvider = mapConfigProvider;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _onKeyPressedEventFilter = _world.Filter<OnKeyPressedEvent>().End();
            _seaBlockTagFilter = _world.Filter<SeaBlockTag>().End();
            
            _onKeyPressedEventPool = _world.GetPool<OnKeyPressedEvent>();
            _positionPool = _world.GetPool<PositionSmooth>();
            _scalePool = _world.GetPool<ScaleSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            if (TryUpdateOffset())
            {
                UpdateMap();
            }
        }

        private bool TryUpdateOffset()
        {
            if (_onKeyPressedEventFilter.GetEntitiesCount() == 0)
            {
                return false;
            }
            
            foreach (var keyPressedEntity in _onKeyPressedEventFilter)
            {
                ref var keyPressedComponent = ref _onKeyPressedEventPool.Get(keyPressedEntity);
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

        private void UpdateMap()
        {
            if (_seaBlockTagFilter.GetEntitiesCount() == 0)
            {
                return;
            }

            foreach (var seaBlockEntityId in _seaBlockTagFilter)
            {
                ref var position = ref _positionPool.Get(seaBlockEntityId);
                ref var scale = ref _scalePool.Get(seaBlockEntityId);
                
                var perlinX = position.Value.x / _mapConfigProvider.MapSize + _offset.x;
                var perlinY = position.Value.z / _mapConfigProvider.MapSize + _offset.y;
                
                var scaleValue = 0f;
                for (var i = 0; i < _mapConfigProvider.MapPerlinParameters.Length; i++)
                {
                    var amplitude = _mapConfigProvider.MapPerlinParameters[i].Amplitude;
                    var frequency = _mapConfigProvider.MapPerlinParameters[i].Frequency;
                    scaleValue += amplitude * Mathf.PerlinNoise(frequency * perlinX, frequency * perlinY);
                }
                
                scale.Value = Vector3.one;
                scale.Value.y = scaleValue;
            }
        }
    }
}