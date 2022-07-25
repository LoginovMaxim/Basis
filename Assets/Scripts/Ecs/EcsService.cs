using System.Collections.Generic;
using System.Threading.Tasks;
using App.Assemblers;
using App.Fsm;
using App.Monos;
using App.Services;
using Leopotam.Ecs;
using Utils;

namespace Ecs
{
    public abstract class EcsService : UpdatableService, IEcsService, IAssemblerPart
    {
        private readonly EcsWorld _world;
        private readonly List<EcsOrderSystem> _orderSystems = new();
        
        private EcsSystems _systems;

        protected EcsService(IWorld world, IMonoUpdater monoUpdater, UpdateType updateType) : 
            base(monoUpdater, updateType, false)
        {
            _world = world.World;
        }

        private Task Launch()
        {
            InitSystems();
            AddSystems();
            BuildSystems();
            AddOneFrameSystems();
            InjectSystemController();
            AddSystemInjects();
            InitSystem();
            Start();
            return Task.CompletedTask;
        }

        protected abstract void AddSystems();
        protected abstract void AddOneFrameSystems();
        protected abstract void AddSystemInjects();
        
        protected void AddSystem(int order, IEcsSystem system, bool isOnlyInitSystem = false)
        {
            CorrectOrderSystem(_orderSystems, ref order);
            var systemName = !isOnlyInitSystem ? TypeUtils.GetConcreteTypeName($"{system.GetType()}") : string.Empty;
            _orderSystems.Add(new EcsOrderSystem(order, system, systemName));
        }
        
        protected void AddOneFrameSystem<T>() where T: struct
        {
            _systems.OneFrame<T>();
        }

        protected void AddSystemInject(object injectObject)
        {
            _systems.Inject(injectObject);
        }

        private void InitSystems()
        {
            _systems?.Destroy();
            _systems = null;
            _systems = new EcsSystems(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
        }

        private void CorrectOrderSystem(List<EcsOrderSystem> systems, ref int order)
        {
            for (var i = 0; i < systems.Count; i++)
            {
                if (systems[i].Order != order)
                {
                    continue;
                }

                order++;
            }
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
                
                if (string.IsNullOrEmpty(_orderSystems[index].SystemName))
                {
                    _systems.Add(_orderSystems[index].EcsSystem);
                }
                else
                {
                    _systems.Add(_orderSystems[index].EcsSystem, _orderSystems[index].SystemName);
                }

                _orderSystems.Remove(_orderSystems[index]);
            }
        }

        private void InjectSystemController()
        {
            AddSystemInject(new SystemController(_systems));
        }

        private void InitSystem()
        {
            _systems.Init();
        }

        protected override void Update()
        {
            _systems.Run();
        }

        protected override void FixedUpdate()
        {
            _systems.Run();
        }

        protected override void LateUpdate()
        {
            _systems.Run();
        }

        protected override void Dispose()
        {
            base.Dispose();

            _systems?.Destroy();
            _systems = null;
        }

        #region IAssemblerPart
        
        Task IAssemblerPart.Launch()
        {
            return Launch();
        }

        #endregion
    }
}