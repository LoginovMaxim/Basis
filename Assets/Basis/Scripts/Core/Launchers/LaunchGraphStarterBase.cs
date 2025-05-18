using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public abstract class LaunchGraphStarterBase : IInitializable
    {
        private readonly ILaunchGraph _launchGraph;

        protected LaunchGraphStarterBase(ILaunchGraph launchGraph)
        {
            _launchGraph = launchGraph;
        }

        public void Initialize()
        {
            LauncherManager.Instance.StartLaunchGraph(_launchGraph);
        }
    }
}