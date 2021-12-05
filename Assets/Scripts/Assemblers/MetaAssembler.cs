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
            TestService testService,
            MetaScreensService metaScreensService)
        {
            InitializeAssemblerParts(
                localization,
                testService,
                metaScreensService);
        }
    }
}