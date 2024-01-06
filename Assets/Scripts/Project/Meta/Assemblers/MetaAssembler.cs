using System.Collections.Generic;
using BasisCore.Runtime.Assemblers;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.UI.LoadingSplash;

namespace Project.Meta.Assemblers
{
    public sealed class MetaAssembler : Assembler
    {
        public MetaAssembler(
            List<IAssemblerLauncher> assemblerParts, 
            LoadingSplashWindowController loadingSplashWindowController) : 
            base(assemblerParts, loadingSplashWindowController)
        {
        }

        protected override void OnStartAssembly()
        {
        }

        protected override void OnFinishAssembly()
        {
        }
    }
}