using System.Collections.Generic;
using Basis.Assemblers;
using Basis.Localizations;
using Basis.Utils;
using Zenject;

namespace Basis.Installers
{
    public sealed class AppAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var assemblerPats = new List<IAssemblerPart>()
            {
                Container.BindAssemblerPart<LocalizationLoader>(),
            };
            
            Container.BindAssembler<AppAssembler>(assemblerPats);
        }
    }
}