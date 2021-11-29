using Services.MetaServices;
using Zenject;

namespace Assemblers
{
    public class MetaAssembler : BaseAssembler
    {
        [Inject]
        public void Inject(
            ProfileService profileService)
        {
            InitializeAssemblerParts(
                profileService);
        }
    }
}