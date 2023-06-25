using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.UI.Splashes;
using Basis.Example.Match.Ecs;
using Basis.Example.Match.UI;

namespace Basis.Example.Match.Assemblers
{
    public sealed class SampleMatchAssembler : Assembler, ISampleMatchAssembler
    {
        private readonly ISampleMatchScreenService _sampleMatchScreenService;
        private readonly ISampleEcsService _sampleEcsService;
        
        public SampleMatchAssembler(
            ISampleMatchScreenService sampleMatchScreenService, 
            ISampleEcsService sampleEcsService, 
            List<IAssemblerPart> assemblerParts, 
            ISplash appSplash) : 
            base(assemblerParts, appSplash)
        {
            _sampleMatchScreenService = sampleMatchScreenService;
            _sampleEcsService = sampleEcsService;
        }

        protected override void OnStartAssembly()
        {
            // nothing
        }

        protected override void OnFinishAssembly()
        {
            _sampleMatchScreenService.ChangeScreen(SampleMatchScreenId.Gameplay);
            _sampleEcsService.Start();
            _splash.Hide();
        }
    }
}