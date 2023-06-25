using System.Collections.Generic;
using Basis.App.Monos;
using Basis.App.Services;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Basis.Ecs
{
    public abstract class EcsService<TEcsSetup> : UpdatableService, IEcsService where TEcsSetup : IEcsSetup
    {
        private readonly List<TEcsSetup> _ecsSetups;
        
        private List<EcsOrderSystem> _orderSystems;
        private EcsSystems _systems;
        
        private EcsWorld _world;

        protected EcsService(
            List<TEcsSetup> ecsSetups, 
            IWorld world, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(monoUpdater, updateType, false)
        {
            _ecsSetups = ecsSetups;
            _world = world.World;
        }

        protected override void Start()
        {
            InitSystems();
            InitSetups();
            AddSystems();
            BuildSystems();
            AddInjects();
            InitInjects();
            InitSystem();
            base.Start();
        }

        private void InitSetups()
        {
            foreach (var levelEcsSetups in _ecsSetups)
            {
                levelEcsSetups.Init(_orderSystems, _systems);
            }
        }

        private void AddSystems()
        {
            foreach (var ecsSetup in _ecsSetups)
            {
                ecsSetup.AddSystems();
            }
        }

        private void AddInjects()
        {
            foreach (var ecsSetup in _ecsSetups)
            {
                ecsSetup.AddInjects();
            }
        }

        private void InitSystems()
        {
            _systems?.Destroy();
            _systems = null;
            _systems = new EcsSystems(_world);
            
            _orderSystems = new List<EcsOrderSystem>();
        }

        private void BuildSystems()
        {
            var systemsCount = _orderSystems.Count;
            
            for (var i = 0; i < systemsCount; i++)
            {
                var order = int.MaxValue;
                var index = 0;
                
                for (var j = 0; j < _orderSystems.Count; j++)
                {
                    if (_orderSystems[j].Order >= order)
                    {
                        continue;
                    }

                    order = _orderSystems[j].Order;
                    index = j;
                }
                
                _systems.Add(_orderSystems[index].EcsSystem);
                _orderSystems.Remove(_orderSystems[index]);
            }
        }

        private void InitInjects()
        {
            _systems.InitShared();
        }

        private void InitSystem()
        {
            _systems.Init();
        }

        protected override void Update()
        {
            _systems.Run();
        }

        protected override void Dispose()
        {
            base.Dispose();

            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
            }
            
            if (_world != null) 
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}