using System;
using BasisCore.GameState;
using BasisCore.Launchers;
using BasisCore.Services;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LauncherManager>().AsSingle().NonLazy();
            
            Container.Bind<AddressablesSceneLoader>().AsSingle().NonLazy();
            
            Container.Bind<IGameState>().To<MetaState>().AsSingle();
            Container.Bind<IGameState>().To<GameplayState>().AsSingle();
            Container.Bind<IGameStateController>().To<GameStateController>().AsSingle();
        }
    }
}