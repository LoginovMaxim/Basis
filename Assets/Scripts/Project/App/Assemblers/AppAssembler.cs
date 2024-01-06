using System.Collections.Generic;
using BasisCore.Runtime.Assemblers;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.UI.LoadingSplash;

namespace Project.App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        public AppAssembler(
            List<IAssemblerLauncher> assemblerParts, 
            LoadingSplashWindowController loadingSplashWindowController) : 
            base(assemblerParts, loadingSplashWindowController)
        {
        }

        protected override void OnStartAssembly()
        {
            _loadingSplashWindowController.Show();
        }

        protected override void OnFinishAssembly()
        {
        }
    }
}