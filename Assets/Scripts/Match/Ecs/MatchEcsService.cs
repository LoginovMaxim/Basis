using System.Collections.Generic;
using BasisCore.Runtime.Monos;
using BasisCore.Runtime.Services;
using BasisLeoEcsWrapper.Runtime;
using Match.Ecs.Setups;

namespace Match.Ecs
{
    public sealed class MatchEcsService : EcsService<IMatchEcsSetup>, IMatchEcsService
    {
        public MatchEcsService(
            List<IMatchEcsSetup> ecsSetups, 
            IMatchEcsWorldProvider matchEcsWorldProvider,
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, matchEcsWorldProvider, monoUpdater, updateType)
        {
        }
    }
}