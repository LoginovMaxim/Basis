using System.Collections.Generic;
using App.Assemblers;
using Example.Match.Ecs;

namespace Example.App.Assemblers
{
    public sealed class SampleAssembler : Assembler, ISampleAssembler
    {
        private readonly ISampleEcsService _sampleEcsService;
        
        public SampleAssembler(ISampleEcsService sampleEcsService, List<IAssemblerPart> assemblerParts) : base(assemblerParts)
        {
            _sampleEcsService = sampleEcsService;
        }

        protected override void FinishAssembly()
        {
            _sampleEcsService.Start();
        }
    }
}