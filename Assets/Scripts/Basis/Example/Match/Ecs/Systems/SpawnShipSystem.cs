using Basis.App.Pool;
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
        private EcsPool<ShipTag> _shipTagPool;

        public SpawnShipSystem(IPoolService poolService)
        {
            _poolService = poolService;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _shipTagPool = _world.GetPool<ShipTag>();
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

            if (!_poolService.TrySpawnView<SampleShipView>(shipEntityId, out var shipView))
            {
                return;
            }
            
            shipView.Transform.position = new Vector3(Random.Range(0f, 50f), Random.Range(1f, 20f), Random.Range(0f, 50f));
            shipView.Transform.localScale = Vector3.one * Random.Range(1f, 3f);
        }

        private void Despawn()
        {
            if (!Input.GetKeyDown(KeyCode.Delete))
            {
                return;
            }
            
            
        }
    }
}