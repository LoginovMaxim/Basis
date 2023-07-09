using Basis.Data;
using Project.App.Data;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DataStorage<AppSettingsStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<DataStorage<PersonalInfoStorageItem>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DataStorage<ProgressStorageItem>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DataStorage<CurrencyStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<PlayerProfileProvider>().AsSingle().NonLazy();
        }
    }
}