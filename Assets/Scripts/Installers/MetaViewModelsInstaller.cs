using UnityEngine;
using ViewModels;
using Zenject;

namespace Installers
{
    public class MetaViewModelsInstaller : MonoInstaller
    {
        [Header("PlayerProfileViewModel")] 
        [SerializeField] private PlayerProfileViewModel PlayerProfileViewModelPrefab;
        [SerializeField] private Transform PlayerProfileViewModelParent;
    
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProfileViewModel>()
                .FromComponentInNewPrefab(PlayerProfileViewModelPrefab)
                .UnderTransform(PlayerProfileViewModelParent)
                .AsSingle()
                .NonLazy();
        }
    }
}