using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public sealed class CommonLaunchGraph : LaunchGraph, IInitializable
    {
        private readonly CoreWindowsLauncher _coreWindowsLauncher;
        private readonly StorageLauncher _storageLauncher;
        private readonly MetaSceneLauncher _metaSceneLauncher;
        
        public CommonLaunchGraph(
            CoreWindowsLauncher coreWindowsLauncher, 
            StorageLauncher storageLauncher, 
            MetaSceneLauncher metaSceneLauncher)
        {
            _coreWindowsLauncher = coreWindowsLauncher;
            _storageLauncher = storageLauncher;
            _metaSceneLauncher = metaSceneLauncher;
        }

        public void Initialize()
        {
            var coreWindowsNode = new LaunchNode(_coreWindowsLauncher, LauncherType.Required, ExecutionMode.Sequential);
            var storageNode = new LaunchNode(_storageLauncher, LauncherType.Required, ExecutionMode.Sequential);
            var metaSceneNode = new LaunchNode(_metaSceneLauncher, LauncherType.Required, ExecutionMode.Sequential);
            
            _roots.Add(coreWindowsNode);
            coreWindowsNode.AddChildNode(storageNode);
            coreWindowsNode.AddChildNode(metaSceneNode);
        }
    }
}