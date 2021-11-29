using Data;
using Monos;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MonoUpdater MonoUpdaterPrefab;
    
        public override void InstallBindings()
        {
            Container.Bind<MonoUpdater>().FromComponentInNewPrefab(MonoUpdaterPrefab).AsSingle().NonLazy();
        
            Container.BindInterfacesAndSelfTo<DataStorage<PlayerMeta>>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DataStorage<PlayerCurrency>>().AsSingle().NonLazy();
        }
    }
}