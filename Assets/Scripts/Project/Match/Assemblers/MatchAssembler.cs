using System.Collections.Generic;
using BasisCore.Runtime.Assemblers;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.UI.LoadingSplash;
using Project.Match.UI;

namespace Project.Match.Assemblers
{
    public sealed class MatchAssembler : Assembler
    {
        private readonly IMatchScreenService _matchScreenService;
        
        public MatchAssembler(
            IMatchScreenService matchScreenService, 
            List<IAssemblerLauncher> assemblerParts, 
            LoadingSplashWindowController loadingSplashWindowController) : 
            base(assemblerParts, loadingSplashWindowController)
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