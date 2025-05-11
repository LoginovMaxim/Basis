using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public sealed class CommonLaunchGraph : LaunchGraph, IInitializable
    {
        private readonly WindowManagerInitializer _windowManagerInitializer;
        private readonly StorageLauncher _storageLauncher;
        private readonly MetaSceneLauncher _metaSceneLauncher;
        
        public CommonLaunchGraph(
            WindowManagerInitializer windowManagerInitializer, 
            StorageLauncher storageLauncher, 
            MetaSceneLauncher metaSceneLauncher)
        {
            _windowManagerInitializer = windowManagerInitializer;
            _storageLauncher = storageLauncher;
            _metaSceneLauncher = metaSceneLauncher;
        }

        public void Initialize()
        {
            var windowManagerNode = new LaunchNode(_windowManagerInitializer, LauncherType.Required, ExecutionMode.Sequential);
            var storageNode = new LaunchNode(_storageLauncher, LauncherType.Required, ExecutionMode.Sequential);
            var metaSceneNode = new LaunchNode(_metaSceneLauncher, LauncherType.Required, ExecutionMode.Sequential);
            
            _roots.Add(windowManagerNode);
            windowManagerNode.AddChildNode(storageNode);
            windowManagerNode.AddChildNode(metaSceneNode);
        }
    }
}