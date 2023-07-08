using System.Collections.Generic;
using Basis.App.Monos;
using Basis.App.Services;
using Basis.App.Views;
using Basis.Ecs;

namespace Basis.Example.Match.Ecs
{
    public sealed class SampleEcsService : EcsService<ISampleEcsSetup>, ISampleEcsService
    {
        public SampleEcsService(
            List<ISampleEcsSetup> ecsSetups,
            IViewsProvider viewsProvider,
            IWorld world, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, viewsProvider, world, monoUpdater, updateType)
        {
        }
        
        void ISampleEcsService.Start()
        {
            Start();
        }
    }
}