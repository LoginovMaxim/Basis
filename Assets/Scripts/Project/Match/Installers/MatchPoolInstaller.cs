using Basis.Pool;
using Basis.Views;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ViewsProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PoolService>().AsSingle().NonLazy();
        }
    }
}