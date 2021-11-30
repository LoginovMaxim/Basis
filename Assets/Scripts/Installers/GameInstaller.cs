using Data;
using Monos;
using UnityEngine;
using ViewModels;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MonoUpdater MonoUpdaterPrefab;
        [SerializeField] private SceneLoader SceneLoaderPrefab;
        [SerializeField] private ViewModelFinder ViewModelFinderPrefab;
    
        public override void InstallBindings()
        {
            Container.Bind<MonoUpdater>().FromComponentInNewPrefab(MonoUpdaterPrefab).AsSingle().NonLazy();
            Container.Bind<ViewModelFinder>().FromComponentInNewPrefab(ViewModelFinderPrefab).AsSingle().NonLazy();

            BindData();
            
            Container.Bind<ILocalizationDataProvider>().To<LocalizationDataProvider>().AsSingle().NonLazy();
            Container.Bind<SceneLoader>().FromComponentInNewPrefab(SceneLoaderPrefab).AsSingle().NonLazy();
        }

        private void BindData()
        {
            Container.BindInterfacesAndSelfTo<DataStorage<PlayerData>>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DataStorage<PlayerCurrency>>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<PlayerProfile>().AsSingle().NonLazy();
        }
    }
}