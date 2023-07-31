using System.Collections.Generic;
using Basis.Assemblers.Launchers;
using Basis.Utils;
using Project.Meta.Assemblers;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var assemblerLaunchers = new List<IAssemblerLauncher>();
            
            Container.BindAssembler<MetaAssembler>(assemblerLaunchers);
        }
    }
}