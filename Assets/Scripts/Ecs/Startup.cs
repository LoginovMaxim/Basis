using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace CoreECS
{
    public sealed class Startup : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PrefabFactory _prefabFactory;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
            EcsSystemsObserver.Create(_systems);
            EcsSystemsObserver.Create(_fixedSystems);
#endif

            _systems
                .Inject(_camera)
                .Inject(_prefabFactory);

            _fixedSystems
                .Inject(_camera)
                .Inject(_prefabFactory);

            _systems.Init();
            _fixedSystems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void FixedUpdate()
        {
            _fixedSystems.Run();
        }

        private void OnDestroy()
        {
            _world?.Destroy();
            _world = null;
            _systems?.Destroy();
            _systems = null;
            _fixedSystems?.Destroy();
            _fixedSystems = null;
        }
    }
}
