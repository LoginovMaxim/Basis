using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.UI.Splashes;
using Basis.Example.Match.Ecs;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleAssembler : Assembler, ISampleAssembler
    {
        private readonly ISampleEcsService _sampleEcsService;
        private readonly IAppSplash _appSplash;
        
        public SampleAssembler(ISampleEcsService sampleEcsService, IAppSplash appSplash, List<IAssemblerPart> assemblerParts) : 
            base(assemblerParts)
        {
            _sampleEcsService = sampleEcsService;
            _appSplash = appSplash;
        }

        protected override void FinishAssembly()
        {
            _sampleEcsService.Start();
            _appSplash.Hide();
        }
    }
}