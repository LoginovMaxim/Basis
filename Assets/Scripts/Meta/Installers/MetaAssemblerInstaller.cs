using System.Collections.Generic;
using App.UI;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Assemblers.Launchers.Window;
using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.UI.Window;
using Meta.Assemblers;
using Meta.Assemblers.Launchers;
using Meta.UI.Main;
using Zenject;

namespace Meta.Installers
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