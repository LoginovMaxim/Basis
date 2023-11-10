using System.Collections.Generic;
using Basis.Assemblers;
using Basis.Assemblers.Launchers;
using Basis.UI.Splashes;
using Project.Match.UI;

namespace Project.Match.Assemblers
{
    public sealed class MatchAssembler : Assembler
    {
        private readonly IMatchScreenService _matchScreenService;
        
        public MatchAssembler(
            IMatchScreenService matchScreenService, 
            List<IAssemblerLauncher> assemblerParts, 
            ISplash splash) : 
            base(assemblerParts, splash)
        {
            _matchScreenService = matchScreenService;
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
            _matchScreenService.SwitchScreen((int) MatchScreenId.Gameplay);
        }
    }
}