using System.Collections.Generic;
using Basis.App.Monos;
using Basis.App.Services;
using Basis.Ecs;

namespace Basis.Example.Match.Ecs
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