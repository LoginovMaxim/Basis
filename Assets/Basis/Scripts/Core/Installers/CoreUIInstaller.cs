using Basis.Core.UI;
using BasisCore.ResourceManagement;
using BasisCore.UI;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIRoot>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<AddressablesResourceProvider>().AsSingle();
            Container.Bind<WindowFactory>().AsSingle();
            Container.Bind<WindowManager>().AsSingle();
            
            Container.Bind<ILoadingSplashWindowViewModel>().To<LoadingSplashWindowViewModel>().AsSingle();
        }
    }
}