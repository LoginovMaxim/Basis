using System.Collections.Generic;
using BasisCore.Runtime.Monos;
using BasisCore.Runtime.Services;
using BasisLeoEcsWrapper.Runtime;
using BasisLeoEcsWrapper.Runtime.Views;
using Match.Ecs.Setups;

namespace Match.Ecs
{
    public sealed class MatchEcsService : EcsService<IMatchEcsSetup>, IMatchEcsService
    {
        public MatchEcsService(
            List<IMatchEcsSetup> ecsSetups, 
            IEcsWorld ecsWorld, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, ecsWorld, monoUpdater, updateType)
        {
        }
    }
}