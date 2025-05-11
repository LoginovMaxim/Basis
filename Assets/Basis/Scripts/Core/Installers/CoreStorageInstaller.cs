using System;
using Basis.Core.Storage;
using BasisCore.Storage;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreStorageInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDisposable>().To<StorageManager>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<AppSettingsProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ProgressProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CurrencyProvider>().AsSingle().NonLazy();
            
            Container.Bind<ProfileProvider>().AsSingle().NonLazy();
        }
    }
}