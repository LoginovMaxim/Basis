using Basis.App.UI.Splashes;
using Zenject;

namespace Basis.App.Installers
{
    public sealed class AppUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AppSplashViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<Splash<AppSplashViewModel>>().AsSingle().NonLazy();
        }
    }
}