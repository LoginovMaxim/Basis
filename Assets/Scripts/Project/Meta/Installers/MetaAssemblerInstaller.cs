using System.Collections.Generic;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.UI.Window;
using Project.App.UI;
using Project.Meta.Assemblers;
using Project.Meta.Assemblers.Launchers;
using Project.Meta.UI.Main;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindWindowLauncher<MainWindowLauncher, MetaMainWindow>(
                windowPrefabResourceKey: WindowNames.Meta.Main, 
                windowLayer: WindowLayer.Main);
            
            var assemblerLaunchers = new List<IAssemblerLauncher>()
            {
                Container.BindAssemblerLauncher<WindowsLauncher<IMetaWindowLauncher>>()
            };
            
            Container.BindAssembler<MetaAssembler>(assemblerLaunchers);
        }
    }
}