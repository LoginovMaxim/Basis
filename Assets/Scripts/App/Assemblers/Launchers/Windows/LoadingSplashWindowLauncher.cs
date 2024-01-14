using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.UI.LoadingSplash;
using BasisCore.Runtime.UI.Window;
using BasisCore.Runtime.UI.Window.Factory;

namespace App.Assemblers.Launchers.Windows
{
    public sealed class LoadingSplashWindowLauncher : WindowLauncher<LoadingSplashWindow>, IAppWindowLauncher
    {
        public LoadingSplashWindowLauncher(
            IWindowViewFactory windowViewFactory, 
            LoadingSplashWindow window, 
            string windowPrefabResourceKey, 
            WindowLayer windowLayer) : 
            base(windowViewFactory, window, windowPrefabResourceKey, windowLayer)
        {
        }
    }
}