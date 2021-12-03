using Localizations;
using ViewModels;
using Zenject;

namespace Assemblers
{
    public class MetaAssembler : Assembler
    {
        [Inject]
        public void Inject(
            Localization localization)
        {
            InitializeAssemblerParts(
                localization);
        }
    }
}