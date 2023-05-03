using System.Collections.Generic;
using App.Fsm;
using App.Monos;
using Ecs;

namespace Example.Ecs
{
    public sealed class SampleEcsService : EcsService, ISampleEcsService
    {
        private readonly List<ISampleEcsSetup> _sampleEcsSetups;

        public SampleEcsService(
            List<ISampleEcsSetup> sampleEcsSetups,
            IWorld world, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(world, monoUpdater, updateType)
        {
            _sampleEcsSetups = sampleEcsSetups;
        }

        protected override void AddSystems()
        {
            InitSetups();
            
#if UNITY_EDITOR
            AddSystem(-1000, new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            
            foreach (var levelEcsSetups in _sampleEcsSetups)
            {
                levelEcsSetups.AddSystems();
            }
        }

        protected override void AddInjects()
        {
            foreach (var levelEcsSetups in _sampleEcsSetups)
            {
                levelEcsSetups.AddInjects();
            }
        }

        private void InitSetups()
        {
            foreach (var levelEcsSetups in _sampleEcsSetups)
            {
                levelEcsSetups.Init(OrderSystems, Systems);
            }
        }

        void ISampleEcsService.Start()
        {
            Start();
        }
    }
}