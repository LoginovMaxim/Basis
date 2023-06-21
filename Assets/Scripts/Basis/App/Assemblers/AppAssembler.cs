using System.Collections.Generic;
using Basis.App.UI.Splashes;

namespace Basis.App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        private IAppSplash _appSplash;
        
        public AppAssembler(IAppSplash appSplash, List<IAssemblerPart> assemblerParts) : base(assemblerParts)
        {
            _appSplash = appSplash;
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
            _appSplash.Hide();
        }
    }
}