﻿using BasisCore.Runtime.Views;
using BasisLeoEcsWrapper.Runtime;
using BasisLeoEcsWrapper.Runtime.Views.Systems;

namespace Match.Ecs.Setups
{
    public sealed class SyncViewMatchEcsSetup : EcsSetup, IMatchEcsSetup
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;

        public SyncViewMatchEcsSetup(IEngineApi engineApi, IViewsProvider viewsProvider)
        {
            _engineApi = engineApi;
            _viewsProvider = viewsProvider;
        }

        public override void AddSystems()
        {
            AddSystem(1000, new SyncViewPositionSystem(_engineApi, _viewsProvider));
            AddSystem(1000, new SyncViewRotationSystem(_engineApi, _viewsProvider));
            AddSystem(1000, new SyncViewScaleSystem(_engineApi, _viewsProvider));
        }
    }
}