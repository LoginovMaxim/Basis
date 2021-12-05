using Assemblers;
using FSM;
using Localizations;
using Services;
using UnityEngine;
using ViewModels.Screens;
using Zenject;

namespace Installers
{
    public class MetaInstaller : MonoInstaller
    {
        [SerializeField] private MetaAssembler _metaAssemblerPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TestMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TestService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MetaScreensService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<Localization>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<MainScreen>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShopScreen>().AsSingle().NonLazy();
            
            Container.Bind<MetaAssembler>().FromComponentInNewPrefab(_metaAssemblerPrefab).AsSingle().NonLazy();
        }
    }
}