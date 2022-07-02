using System.Collections.Generic;
using System.Threading.Tasks;
using App.Assemblers;
using App.Monos;
using App.Services;
using App.UI.Services;
using Ecs.Common.Events;
using Ecs.Common.Systems;
using Leopotam.Ecs;
using Utils;
using VisualEffects;
using Zenject;

namespace Ecs
{
    public abstract class BaseEcsWorldService : UpdatableService, IAssemblerPart
    {
        protected EcsWorld World;
        protected EcsSystems Systems;
        protected EcsSystems FixedSystems;

        protected List<EcsSystemData> _systems = new List<EcsSystemData>();
        protected List<EcsSystemData> _fixedSystems = new List<EcsSystemData>();

        [Inject] private readonly IPrefabFactory _prefabFactory;
        [Inject] private readonly IScreenService _screenService;
        [Inject] private readonly IPopupService _popupService;
        [Inject] private readonly IEffectEmitter _effectEmitter;
        
        private ISystemController _systemController;

        protected BaseEcsWorldService(IMonoUpdater monoUpdater) : base(monoUpdater)
        {
        }

        private Task Launch()
        {
            World = new EcsWorld();
            Systems = new EcsSystems(World);
            FixedSystems = new EcsSystems(World);

            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(Systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(FixedSystems);

            AddSystems();
            AddFixedSystems();

            BuildSystems(Systems, _systems);
            BuildSystems(FixedSystems, _fixedSystems);

            AddOneFramesToSystems();
            AddOneFramesToFixedSystems();

            AddInjectSystems();
            AddInjectFixedSystems();

            InitSystems();

            _prefabFactory.ConvertAllMonoEntitiesInScene();
            
            Start();
            return Task.CompletedTask;
        }

        protected virtual void AddSystems()
        {
            AddSystem(-1000, new ConvertAllMonoEntitiesSystem(), true);
            AddSystem(1000, new SpawnSystem());
            AddSystem(1000, new EmitEffectSystem());
        }

        protected virtual void AddFixedSystems()
        {
        }

        protected void AddSystem(int order, IEcsSystem system, bool isOnlyInitSystem = false)
        {
            CorrectOrderSystem(_systems, ref order);
            var systemName = !isOnlyInitSystem ? TypeUtils.GetConcreteTypeName($"{system.GetType()}") : string.Empty;
            _systems.Add(new EcsSystemData(order, system, systemName));
        }

        protected void AddFixedSystem(int order, IEcsSystem system, string name = null)
        {
            CorrectOrderSystem(_fixedSystems, ref order);
            _fixedSystems.Add(new EcsSystemData(order, system, name));
        }

        private void CorrectOrderSystem(List<EcsSystemData> systems, ref int order)
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

        private void BuildSystems(EcsSystems ecsSystems, List<EcsSystemData> systems)
        {
            var systemsCount = systems.Count;
            
            for (var i = 0; i < systemsCount; i++)
            {
                var order = int.MaxValue;
                var index = 0;
                
                for (var j = 0; j < systems.Count; j++)
                {
                    if (systems[j].Order >= order)
                    {
                        continue;
                    }

                    order = systems[j].Order;
                    index = j;
                }
                
                if (string.IsNullOrEmpty(systems[index].SystemName))
                {
                    ecsSystems.Add(systems[index].EcsSystem);
                }
                else
                {
                    ecsSystems.Add(systems[index].EcsSystem, systems[index].SystemName);
                }

                systems.Remove(systems[index]);
            }
        }

        protected virtual void AddOneFramesToSystems()
        {
            Systems
                .OneFrame<OnTriggerEnterEvent>()
                .OneFrame<OnTriggerStayEvent>()
                .OneFrame<OnEmitEffectRequested>()
                .OneFrame<OnMouseButtonDownEvent>()
                .OneFrame<OnMouseButtonUpEvent>();
        }

        protected virtual void AddOneFramesToFixedSystems()
        {
            FixedSystems
                .OneFrame<OnMouseButtonDownFixedEvent>()
                .OneFrame<OnMouseButtonUpFixedEvent>();
        }

        protected virtual void AddInjectSystems()
        {
            _systemController = new SystemController(Systems);

            Systems
                .Inject(_systemController)
                .Inject(_prefabFactory)
                .Inject(_screenService)
                .Inject(_popupService)
                .Inject(_effectEmitter);
        }

        protected virtual void AddInjectFixedSystems()
        {
        }

        private void InitSystems()
        {
            Systems.Init();
            FixedSystems.Init();
        }

        protected override void Update()
        {
            Systems.Run();
        }

        protected override void FixedUpdate()
        {
            FixedSystems.Run();
        }

        protected override void Dispose()
        {
            base.Dispose();
            
            World?.Destroy();
            World = null;

            Systems?.Destroy();
            Systems = null;

            FixedSystems?.Destroy();
            FixedSystems = null;
        }

        #region IAssemblerPart
        
        Task IAssemblerPart.Launch()
        {
            return Launch();
        }

        #endregion
    }
}