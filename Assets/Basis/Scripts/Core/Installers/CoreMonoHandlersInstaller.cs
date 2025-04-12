using BasisCore.Monos;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreMonoHandlersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MonoUpdater>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameObjectFinder>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ApplicationStatusHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}