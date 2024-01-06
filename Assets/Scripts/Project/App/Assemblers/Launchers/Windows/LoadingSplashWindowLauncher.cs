using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.UI.LoadingSplash;
using BasisCore.Runtime.UI.Window;
using BasisCore.Runtime.UI.Window.Factory;

namespace Project.App.Assemblers.Launchers.Windows
{
    public sealed class LoadingSplashWindowLauncher : WindowLauncher<LoadingSplashWindowController>, IAppWindowLauncher
    {
        public LoadingSplashWindowLauncher(
            IWindowViewFactory windowViewFactory, 
            LoadingSplashWindowController windowController, 
            string windowPrefabResourceKey, 
            WindowLayer windowLayer) : 
            base(windowViewFactory, windowController, windowPrefabResourceKey, windowLayer)
        {
        }
    }
}