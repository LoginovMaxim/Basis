using System.Collections.Generic;
using App.Fsm;
using App.Monos;
using Ecs;

namespace Example.Match.Ecs
{
    public sealed class SampleEcsService : EcsService<ISampleEcsSetup>, ISampleEcsService
    {
        public SampleEcsService(
            List<ISampleEcsSetup> ecsSetups, 
            IWorld world, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, world, monoUpdater, updateType)
        {
        }
        
        void ISampleEcsService.Start()
        {
            Start();
        }
    }
}