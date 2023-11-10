using System.Collections.Generic;
using System.Threading.Tasks;
using Basis.Assemblers;
using Basis.Assemblers.Launchers;
using Basis.UI.Splashes;
using Project.Meta.UI;

namespace Project.Meta.Assemblers
{
    public sealed class MetaAssembler : Assembler
    {
        private readonly IMetaScreenService _metaScreenService;
        
        public MetaAssembler(
            IMetaScreenService metaScreenService, 
            List<IAssemblerLauncher> assemblerParts, 
            ISplash splash) : 
            base(assemblerParts, splash)
        {
            _metaScreenService = metaScreenService;
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
            _metaScreenService.SwitchScreen((int)MetaScreenId.Main);
        }
    }
}