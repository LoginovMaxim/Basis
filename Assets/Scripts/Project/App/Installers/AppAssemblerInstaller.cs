using System.Collections.Generic;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.Utils;
using Project.App.Assemblers;
using Project.App.Assemblers.Launchers;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var assemblerLaunchers = new List<IAssemblerLauncher>()
            {
                Container.BindAssemblerLauncher<LocalizationLauncher>(),
                Container.BindAssemblerLauncher<MetaSceneLauncher>()
            };
            
            Container.BindAssembler<AppAssembler>(assemblerLaunchers);
        }
    }
}