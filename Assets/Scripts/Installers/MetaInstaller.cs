using Assemblers;
using Services.MetaServices;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MetaInstaller : MonoInstaller
    {
        [SerializeField] private MetaAssembler MetaAssemblerPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProfileService>().AsSingle().NonLazy();
        
            Container.Bind<MetaAssembler>().FromComponentInNewPrefab(MetaAssemblerPrefab).AsSingle().NonLazy();
        }
    }
}