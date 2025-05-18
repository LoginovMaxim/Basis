using Basis.Core.Launchers;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreLaunchersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CoreWindowsLauncher>().AsSingle().NonLazy();
            Container.Bind<StorageLauncher>().AsSingle().NonLazy();
            Container.Bind<MetaSceneLauncher>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<CommonLaunchGraph>().AsSingle().NonLazy();
            Container.Bind<IInitializable>().To<CoreLaunchGraphStarter>().AsSingle().NonLazy();
        }
    }
}