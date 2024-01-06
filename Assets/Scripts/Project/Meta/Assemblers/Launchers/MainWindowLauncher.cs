using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.UI.Window;
using BasisCore.Runtime.UI.Window.Factory;
using Project.Meta.UI.Main;

namespace Project.Meta.Assemblers.Launchers
{
    public sealed class MainWindowLauncher : WindowLauncher<MetaMainWindowController>, IMetaWindowLauncher
    {
        public MainWindowLauncher(
            IWindowViewFactory windowViewFactory, 
            MetaMainWindowController windowController, 
            string windowPrefabResourceKey, 
            WindowLayer windowLayer) : 
            base(windowViewFactory, windowController, windowPrefabResourceKey, windowLayer)
        {
        }
    }
}