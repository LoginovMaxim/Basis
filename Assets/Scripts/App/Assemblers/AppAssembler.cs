using App.Localizations;
using Zenject;

namespace App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        [Inject] public void Inject(
            Localization localization)
        {
            InitializeAssemblerParts(
                localization);
        }
    }
}