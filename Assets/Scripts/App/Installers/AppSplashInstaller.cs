using App.UI.Splashes;
using Zenject;

namespace App.Installers
{
    public sealed class AppSplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AppSplashViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesTo<AppSplash>().AsSingle().NonLazy();
        }
    }
}