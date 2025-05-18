using Basis.Meta.Launchers;
using Zenject;

namespace Basis.Meta.Installers
{
    public sealed class MetaLauncherInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MetaWindowsLauncher>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<MetaLaunchGraph>().AsSingle().NonLazy();
            Container.Bind<IInitializable>().To<MetaLaunchGraphStarter>().AsSingle().NonLazy();
        }
    }
}