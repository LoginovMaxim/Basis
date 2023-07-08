using System.Collections.Generic;
using Basis.UI.Splashes;

namespace Basis.Assemblers
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