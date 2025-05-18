using BasisCore.Launchers;
using Zenject;

namespace Basis.Meta.Launchers
{
    public class MetaLaunchGraph : LaunchGraph, IInitializable
    {
        private readonly MetaWindowsLauncher _metaWindowsLauncher;

        public MetaLaunchGraph(MetaWindowsLauncher metaWindowsLauncher)
        {
            _metaWindowsLauncher = metaWindowsLauncher;
        }

        public void Initialize()
        {
            var metaWindowsLauncher = new LaunchNode(_metaWindowsLauncher, LauncherType.Required, ExecutionMode.Sequential);
            _roots.Add(metaWindowsLauncher);
        }
    }
}