using Basis.App.Pool;
using Basis.Ecs.Common.Components;
using Basis.Example.Match.Ecs.Components;
using Basis.Example.Match.Views;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class SpawnShipSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IPoolService _poolService;

        private EcsWorld _world;
        private EcsFilter _shipTagFilter;
        private EcsPool<ShipTag> _shipTagPool;
        private EcsPool<PositionSmooth> _positionSmoothPool;
        private EcsPool<ScaleSmooth> _scaleSmoothPool;

        public SpawnShipSystem(IPoolService poolService)
        {
            _poolService = poolService;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _shipTagFilter = _world.Filter<ShipTag>().End();
            
            _shipTagPool = _world.GetPool<ShipTag>();
            _positionSmoothPool = _world.GetPool<PositionSmooth>();
            _scaleSmoothPool = _world.GetPool<ScaleSmooth>();
        }

        public void Run(IEcsSystems systems)
        {
            Spawn();
            Despawn();
        }

        private void Spawn()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            var shipEntityId = _world.NewEntity();
            _shipTagPool.Add(shipEntityId);
            
            ref var shipPositionSmooth = ref _positionSmoothPool.Add(shipEntityId);
            shipPositionSmooth.Value = new Vector3(Random.Range(0f, 50f), Random.Range(1f, 20f), Random.Range(0f, 50f));
            shipPositionSmooth.Smooth = 2f;
            
            ref var shipScaleSmooth = ref _scaleSmoothPool.Add(shipEntityId);
            shipScaleSmooth.Value = Vector3.one * Random.Range(1f, 3f);
            shipScaleSmooth.Smooth = 0.5f;

            _poolService.TrySpawnView<SampleShipView>(shipEntityId, out var view);
            view.Transform.position = shipPositionSmooth.Value;
        }

        private void Despawn()
        {
            if (!Input.GetKeyDown(KeyCode.Delete))
            {
                return;
            }

            foreach (var e in _shipTagFilter)
            {
                _poolService.TryDespawnView(e);
                _world.DelEntity(e);
                return;
            }
        }
    }
}