using System.Collections.Generic;
using Basis.Assemblers.Launchers;
using Basis.Utils;
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