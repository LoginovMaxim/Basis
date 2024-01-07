using BasisCore.Runtime.Commands;
using Project.App.Commands;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppCommandsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayMatchCommand>().AsSingle().NonLazy();
            Container.BindInterfacesTo<QuitMatchCommand>().AsSingle().NonLazy();
            Container.BindInterfacesTo<RestartMatchCommand>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ProgressServiceAddCommand>().AsSingle().NonLazy();
        }
    }
}