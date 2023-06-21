using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.UI.Splashes;
using Basis.Example.Match.Ecs;
using Basis.Example.Match.UI;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMatchAssembler : Assembler, ISampleMatchAssembler
    {
        private readonly ISampleMatchScreenService _sampleMatchScreenService;
        private readonly ISampleEcsService _sampleEcsService;
        private readonly IAppSplash _appSplash;
        
        public SampleMatchAssembler(
            ISampleMatchScreenService sampleMatchScreenService, 
            ISampleEcsService sampleEcsService, 
            IAppSplash appSplash, 
            List<IAssemblerPart> assemblerParts) : 
            base(assemblerParts)
        {
            _sampleMatchScreenService = sampleMatchScreenService;
            _sampleEcsService = sampleEcsService;
            _appSplash = appSplash;
        }

        protected override void FinishAssembly()
        {
            _sampleMatchScreenService.ChangeScreen(SampleMatchScreenId.Gameplay);
            _sampleEcsService.Start();
            _appSplash.Hide();
        }
    }
}