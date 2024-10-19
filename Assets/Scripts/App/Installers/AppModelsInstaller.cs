using BasisCore.Runtime.UI.LoadingSplash;
using Zenject;

namespace App.Installers
{
    public sealed class AppModelsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingSplashWindowModel>().AsSingle().NonLazy();
        }
    }
}