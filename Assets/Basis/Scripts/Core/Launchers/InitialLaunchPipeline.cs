using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public sealed class InitialLaunchPipeline : IInitializable
    {
        private readonly MetaSceneLauncher _metaSceneLauncher;
        
        public InitialLaunchPipeline(MetaSceneLauncher metaSceneLauncher)
        {
            _metaSceneLauncher = metaSceneLauncher;
        }

        public void Initialize()
        {
            LauncherManager.Instance.AddLauncher(_metaSceneLauncher);
            LauncherManager.Instance.StartLaunchPipeline();
        }
    }
}