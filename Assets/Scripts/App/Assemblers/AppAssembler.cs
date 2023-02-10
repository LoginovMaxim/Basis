using System.Collections.Generic;

namespace App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        public AppAssembler(List<IAssemblerPart> assemblerParts) : base(assemblerParts)
        {
        }
    }
}