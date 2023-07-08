using System.Collections.Generic;
using Basis.App.UI.Splashes;

namespace Basis.App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        public AppAssembler(List<IAssemblerPart> assemblerParts, ISplash splash) : base(assemblerParts, splash)
        {
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
        }
    }
}