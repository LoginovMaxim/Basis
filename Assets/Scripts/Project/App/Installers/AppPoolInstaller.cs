using Basis.Pool;
using Basis.Views;
using Zenject;

namespace Basis.Installers
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