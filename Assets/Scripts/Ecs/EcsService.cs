using System.Collections.Generic;
using System.Threading.Tasks;
using App.Assemblers;
using App.Fsm;
using App.Monos;
using App.Services;
using GoodCat.EcsLite.Shared;
using Leopotam.EcsLite;

namespace Ecs
{
    public abstract class EcsService : UpdatableService, IEcsService, IAssemblerPart
    {
        private readonly List<EcsOrderSystem> _orderSystems = new();
        
        private EcsWorld _world;
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
            AddInjects();
            InitInjects();
            InitSystem();
            Start();
            return Task.CompletedTask;
        }

        protected abstract void AddSystems();
        protected abstract void AddInjects();
        
        protected void AddSystem(int order, IEcsSystem system)
        {
            CorrectOrderSystem(_orderSystems, ref order);
            _orderSystems.Add(new EcsOrderSystem(order, system));
        }

        protected void AddInject<T>(T shared) where T : class
        {
            _systems.InjectShared(shared);
        }

        private void InitSystems()
        {
            _systems?.Destroy();
            _systems = null;
            _systems = new EcsSystems(_world);
            //Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
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

            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) 
            {
                _world.Destroy ();
                _world = null;
            }
        }

        #region IAssemblerPart
        
        Task IAssemblerPart.Launch()
        {
            return Launch();
        }

        #endregion
    }
}