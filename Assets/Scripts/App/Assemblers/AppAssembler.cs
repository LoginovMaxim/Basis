using App.Localizations;
using Zenject;

namespace App.Assemblers
{
    public sealed class AppAssembler : Assembler
    {
        [Inject] public async void Inject(
            Localization localization)
        {
            await LaunchAssemblerPartsAsync(
                localization);
        }
    }
}