using BasisLeoEcsWrapper.Runtime;
using BasisLeoEcsWrapper.Runtime.Views;
using BasisLeoEcsWrapper.Runtime.Views.Systems;

namespace Match.Ecs.Setups
{
    public sealed class SyncViewMatchEcsSetup : EcsSetup, IMatchEcsSetup
    {
        /*private readonly IEngineApi _engineApi;
        private readonly IEcsViewsProvider _ecsViewsProvider;

        public SyncViewMatchEcsSetup(IEngineApi engineApi, IEcsViewsProvider ecsViewsProvider)
        {
            _engineApi = engineApi;
            _ecsViewsProvider = ecsViewsProvider;
        }*/

        public override void AddSystems()
        {
            /*AddSystem(1000, new SyncViewPositionSystem(_engineApi, _ecsViewsProvider));
            AddSystem(1000, new SyncViewRotationSystem(_engineApi, _ecsViewsProvider));
            AddSystem(1000, new SyncViewScaleSystem(_engineApi, _ecsViewsProvider));*/
        }
    }
}