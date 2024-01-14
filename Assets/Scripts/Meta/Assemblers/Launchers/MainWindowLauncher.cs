using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.UI.Window;
using BasisCore.Runtime.UI.Window.Factory;
using Meta.UI.Main;

namespace Meta.Assemblers.Launchers
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