using Project.App.UI.Splashes;
using Project.LoadingSplash.Services;
using Zenject;

namespace Project.LoadingSplash.Installers
{
    public sealed class LoadingSplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingSplashViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<LoadingSplashMediator>().AsSingle().NonLazy();
        }
    }
}