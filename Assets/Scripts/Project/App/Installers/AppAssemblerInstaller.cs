using System.Collections.Generic;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.UI.LoadingSplash;
using BasisCore.Runtime.UI.Window;
using Project.App.Assemblers;
using Project.App.Assemblers.Launchers;
using Project.App.Assemblers.Launchers.Windows;
using Project.App.UI;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindWindowLauncher<LoadingSplashWindowLauncher, LoadingSplashWindow>(
                windowPrefabResourceKey: WindowNames.App.LoadingSplash, 
                windowLayer: WindowLayer.LoadingSplash);
            
            var assemblerLaunchers = new List<IAssemblerLauncher>()
            {
                Container.BindAssemblerLauncher<WindowsLauncher<IAppWindowLauncher>>(),
                Container.BindAssemblerLauncher<LocalizationLauncher>(),
                Container.BindAssemblerLauncher<MetaSceneLauncher>(),
            };
            
            Container.BindAssembler<AppAssembler>(assemblerLaunchers);
        }
    }
}