using UnityEngine;
using ViewModels;
using ViewModels.Screens;
using Zenject;

namespace Installers
{
    public class MetaViewModelsInstaller : MonoInstaller
    {
        [Header("Player Profile")] 
        [SerializeField] private PlayerProfileViewModel _playerProfileViewModelPrefab;
        [SerializeField] private Transform _playerProfileViewModelParent;
        
        [Header("Meta Main Screen")] 
        [SerializeField] private MainScreenViewModel _mainScreenViewModelPrefab;
        [SerializeField] private Transform _mainScreenViewModelParent;
        [Header("Shop Screen")] 
        [SerializeField] private ShopScreenViewModel _shopScreenViewModelPrefab;
        [SerializeField] private Transform _shopScreenViewModelParent;
    
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProfileViewModel>()
                .FromComponentInNewPrefab(_playerProfileViewModelPrefab)
                .UnderTransform(_playerProfileViewModelParent)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindFactory<MainScreenViewModel, MainScreenViewModel.Factory>()
                .FromComponentInNewPrefab(_mainScreenViewModelPrefab)
                .UnderTransform(_mainScreenViewModelParent)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindFactory<ShopScreenViewModel, ShopScreenViewModel.Factory>()
                .FromComponentInNewPrefab(_shopScreenViewModelPrefab)
                .UnderTransform(_shopScreenViewModelParent)
                .AsSingle()
                .NonLazy();
        }
    }
}