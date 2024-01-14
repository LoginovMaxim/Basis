using System.Collections.Generic;
using BasisCore.Runtime.Monos;
using BasisCore.Runtime.Services;
using BasisCore.Runtime.Views;
using BasisLeoEcsWrapper.Runtime;
using Match.Ecs.Setups;

namespace Match.Ecs
{
    public sealed class MatchEcsService : EcsService<IMatchEcsSetup>, IMatchEcsService
    {
        public MatchEcsService(
            List<IMatchEcsSetup> ecsSetups, 
            IViewsProvider viewsProvider, 
            IEcsWorld ecsWorld, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, viewsProvider, ecsWorld, monoUpdater, updateType)
        {
        }
    }
}