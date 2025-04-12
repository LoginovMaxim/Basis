using System.Collections.Generic;
using Basis.Gameplay.Ecs.Setups;
using BasisCore.Monos;
using BasisCore.Services;
using BasisLeoEcsWrapper.Runtime;

namespace Basis.Gameplay.Ecs
{
    public sealed class MatchEcsService : EcsService<IMatchEcsSetup>, IMatchEcsService
    {
        public MatchEcsService(
            List<IMatchEcsSetup> ecsSetups, 
            IMatchEcsWorldProvider matchEcsWorldProvider,
            MonoUpdater monoUpdater, 
            UpdateType updateType) : 
            base(ecsSetups, matchEcsWorldProvider, monoUpdater, updateType)
        {
        }
    }
}