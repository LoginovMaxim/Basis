using Basis.App.Views;
using Basis.Ecs;
using Basis.Example.Match.Ecs.Systems;

namespace Basis.Example.Match.Ecs.Setups
{
    public sealed class SampleSyncEcsSetup : EcsSetup, ISampleEcsSetup
    {
        private readonly IEngineApi _engineApi;
        private readonly IViewsProvider _viewsProvider;

        public SampleSyncEcsSetup(IEngineApi engineApi, IViewsProvider viewsProvider)
        {
            _engineApi = engineApi;
            _viewsProvider = viewsProvider;
        }

        public override void AddSystems()
        {
            AddSystem(10000, new SyncViewPositionSystem(_engineApi, _viewsProvider));
            AddSystem(10000, new SyncViewScaleSystem(_engineApi, _viewsProvider));
        }

        public override void AddInjects()
        {
        }
    }
}