using Basis.App.Pool;
using Basis.App.Views;
using Zenject;

namespace Basis.App.Installers
{
    public sealed class AppPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ViewsProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PoolService>().AsSingle().NonLazy();
        }
    }
}