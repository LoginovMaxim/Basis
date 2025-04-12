using Basis.Core.Storage;
using BasisCore.Storage;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Storage<AppSettingsStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<Storage<PersonalInfoStorageItem>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<Storage<ProgressStorageItem>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<Storage<CurrencyStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<ProfileProvider>().AsSingle().NonLazy();
        }
    }
}