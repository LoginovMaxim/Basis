using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.UI.Window;
using BasisCore.Runtime.UI.Window.Factory;
using Project.Meta.UI.Main;

namespace Project.Meta.Assemblers.Launchers
{
    public sealed class MainWindowLauncher : WindowLauncher<MetaMainWindow>, IMetaWindowLauncher
    {
        public MainWindowLauncher(
            IWindowViewFactory windowViewFactory, 
            MetaMainWindow window, 
            string windowPrefabResourceKey, 
            WindowLayer windowLayer) : 
            base(windowViewFactory, window, windowPrefabResourceKey, windowLayer)
        {
        }
    }
}