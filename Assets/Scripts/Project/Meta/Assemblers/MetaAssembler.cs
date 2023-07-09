using System.Collections.Generic;
using Basis.Assemblers;
using Basis.Assemblers.Launchers;
using Basis.UI.Splashes;

namespace Project.Meta.Assemblers
{
    public sealed class MetaAssembler : Assembler
    {
        public MetaAssembler(List<IAssemblerLauncher> assemblerParts, ISplash splash) : base(assemblerParts, splash)
        {
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
            _splash.Hide();
        }
    }
}