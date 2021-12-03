using Assemblers;
using FSM;
using Localizations;
using UnityEngine;
using ViewModels;
using Zenject;

namespace Installers
{
    public class MetaInstaller : MonoInstaller
    {
        [SerializeField] private MetaAssembler _metaAssemblerPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TestMachine>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<Localization>().AsSingle().NonLazy();
            Container.Bind<MetaAssembler>().FromComponentInNewPrefab(_metaAssemblerPrefab).AsSingle().NonLazy();
        }
    }
}