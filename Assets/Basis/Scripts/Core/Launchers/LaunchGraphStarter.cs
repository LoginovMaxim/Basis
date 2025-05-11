using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public sealed class LaunchGraphStarter : IInitializable
    {
        private readonly ILaunchGraph _launchGraph;

        public LaunchGraphStarter(ILaunchGraph launchGraph)
        {
            _launchGraph = launchGraph;
        }

        public void Initialize()
        {
            LauncherManager.Instance.StartLaunchGraph(_launchGraph);
        }
    }
}