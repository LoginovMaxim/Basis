using System.Collections.Generic;
using Basis.Ecs;
using Basis.Monos;
using Basis.Services;
using Basis.Views;
using Project.Match.Ecs.Setups;

namespace Project.Match.Ecs
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