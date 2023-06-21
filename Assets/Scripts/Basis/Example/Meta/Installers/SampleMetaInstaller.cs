using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.Example.App.Assemblers;
using Basis.Example.Meta.Assemblers;
using Basis.Utils;
using Zenject;

namespace Basis.Example.Meta.Installers
{
    public sealed class SampleMetaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var assemblers = new List<IAssemblerPart>()
            {
                Container.BindAssemblerPart<SampleMetaInitializer>(),
            };
            
            Container.BindAssembler<SampleMetaAssembler>(assemblers);
        }
    }
}