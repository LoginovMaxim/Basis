using System.Collections.Generic;
using App.Assemblers;
using App.Assemblers.Launchers;
using App.Assemblers.Launchers.Windows;
using App.UI;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.UI.LoadingSplash;
using BasisCore.Runtime.UI.Window;
using Zenject;

namespace App.Installers
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