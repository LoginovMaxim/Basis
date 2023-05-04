using System.Collections.Generic;
using App.Assemblers;
using App.UI.Splashes;
using Example.Match.Ecs;

namespace Example.App.Assemblers
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