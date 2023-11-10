using System.Collections.Generic;
using Basis.Assemblers;
using Basis.Assemblers.Launchers;
using Basis.UI.Splashes;

namespace Project.App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        public AppAssembler(List<IAssemblerLauncher> assemblerParts, ISplash splash) : base(assemblerParts, splash)
        {
        }

        protected override void OnStartAssembly()
        {
            _splash.Show();
        }

        protected override void OnFinishAssembly()
        {
        }
    }
}