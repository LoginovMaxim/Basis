using System;
using Basis.Core.Launchers;
using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreLaunchersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDisposable>().To<LauncherManager>().AsSingle().NonLazy();
            
            Container.Bind<MetaSceneLauncher>().AsSingle().NonLazy();
            
            Container.Bind<IInitializable>().To<InitialLaunchPipeline>().AsSingle().NonLazy();
        }
    }
}