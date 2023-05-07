using System.Collections.Generic;
using App.Assemblers;
using App.Data;
using App.Fsm;
using App.Localizations;
using App.Monos;
using Ecs;
using Example.App.Assemblers;
using UnityEngine;
using Utils;
using VisualEffects;
using Zenject;

namespace App.Installers
{
    public sealed class AppInstaller : MonoInstaller
    {
        public bool RunExample;
        
        [SerializeField] private MonoUpdater MonoUpdater;
        [SerializeField] private SceneLoader SceneLoader;
        [SerializeField] private GameObjectFinder GameObjectFinder;
        [SerializeField] private PrefabFactory PrefabFactory;
    
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.BindInterfacesTo<MonoUpdater>().FromComponentInNewPrefab(MonoUpdater).AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoader>().FromComponentInNewPrefab(SceneLoader).AsSingle().NonLazy();
            Container.BindInterfacesTo<GameObjectFinder>().FromComponentInNewPrefab(GameObjectFinder).AsSingle().NonLazy();
            Container.BindInterfacesTo<PrefabFactory>().FromComponentInNewPrefab(PrefabFactory).AsSingle().NonLazy();
            Container.BindInterfacesTo<EffectEmitter>().AsSingle().NonLazy();
            
            BindData();
            
            Container.BindInterfacesTo<Localization>().AsSingle().NonLazy();

            var assemblerPats = new List<IAssemblerPart>();
            assemblerPats.Add(Container.BindAssemblerPart<LocalizationLoader>());
            
            if (RunExample)
            {
                assemblerPats.Add(Container.BindAssemblerPart<SampleSomethingLoader>());
                assemblerPats.Add(Container.BindAssemblerPart<SampleAuthorization>());
                assemblerPats.Add(Container.BindAssemblerPart<SampleMetaLoader>());
            }
            else
            {
                // your load pipeline
            }
            
            Container.BindAssembler<AppAssembler>(assemblerPats);
        }

        private void BindData()
        {
            Container.BindInterfacesTo<DataStorage<AppSettingsStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<DataStorage<PlayerProfileStorageItem>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DataStorage<PlayerCurrencyStorageItem>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<PlayerProfile>().AsSingle().NonLazy();
        }
    }
}