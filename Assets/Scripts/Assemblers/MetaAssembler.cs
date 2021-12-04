using Localizations;
using Services;
using Zenject;

namespace Assemblers
{
    public class MetaAssembler : Assembler
    {
        [Inject]
        public void Inject(
            Localization localization,
            TestService testService)
        {
            InitializeAssemblerParts(
                localization,
                testService);
        }
    }
}