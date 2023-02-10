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
        public bool RunExampleScene;
        
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

            Container.BindFactory<StateMachine, StateMachine.Factory>().AsTransient().NonLazy();
            
            BindData();
            
            Container.BindInterfacesTo<Localization>().AsSingle().NonLazy();
            
            Container.BindAssemblerPart<LocalizationLoader>();

            var assemblerPats = new List<IAssemblerPart>();
            assemblerPats.Add(Container.Resolve<LocalizationLoader>());
            
            if (RunExampleScene)
            {
                Container.BindAssemblerPart<ExampleSceneLoader>();
                assemblerPats.Add(Container.Resolve<ExampleSceneLoader>());
            }
            
            Container.BindAssembler<AppAssembler>(assemblerPats);
        }

        private void BindData()
        {
            Container.BindInterfacesTo<DataStorage<PlayerData>>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DataStorage<PlayerCurrency>>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<PlayerProfile>().AsSingle().NonLazy();
        }
    }
}