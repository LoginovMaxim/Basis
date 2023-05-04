using System.Collections.Generic;
using App.Assemblers;

namespace Example.App.Assemblers
{
    public sealed class SampleAssembler : Assembler, ISampleAssembler
    {
        public SampleAssembler(List<IAssemblerPart> assemblerParts) : base(assemblerParts)
        {
        }

        protected override void FinishAssembly()
        {
            // nothing
        }
    }
}