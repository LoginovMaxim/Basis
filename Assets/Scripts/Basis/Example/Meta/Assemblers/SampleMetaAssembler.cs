using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.UI.Splashes;
using Basis.Example.Meta.UI;

namespace Basis.Example.Meta.Assemblers
{
    public sealed class SampleMetaAssembler : Assembler
    {
        private readonly ISampleMetaScreenService _sampleMetaScreenService;
        
        public SampleMetaAssembler(
            ISampleMetaScreenService sampleMetaScreenService, 
            List<IAssemblerPart> assemblerParts, 
            ISplash splash) : 
            base(assemblerParts, splash)
        {
            _sampleMetaScreenService = sampleMetaScreenService;
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
            _sampleMetaScreenService.ChangeScreen(SampleMetaScreenId.Main);
        }
    }
}