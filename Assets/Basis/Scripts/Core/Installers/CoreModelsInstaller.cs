using Basis.Core.UI;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreModelsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingSplashModel>().AsSingle();
        }
    }
}