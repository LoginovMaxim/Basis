using System.Collections.Generic;
using App.UI.Splashes;

namespace App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        private IAppSplash _appSplash;
        
        public AppAssembler(IAppSplash appSplash, List<IAssemblerPart> assemblerParts) : base(assemblerParts)
        {
            _appSplash = appSplash;
        }

        protected override void FinishAssembly()
        {
            _appSplash.Hide();
        }
    }
}