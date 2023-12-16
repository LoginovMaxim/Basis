using BasisCore.Runtime.Monos;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppMonoHandlersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MonoUpdater>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameObjectFinder>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ApplicationStatusHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}