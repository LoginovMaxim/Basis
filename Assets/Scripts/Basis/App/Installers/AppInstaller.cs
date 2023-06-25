using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.Data;
using Basis.App.Localizations;
using Basis.App.Monos;
using Basis.Ecs;
using Basis.Example.App.Assemblers;
using Basis.Utils;
using Basis.VisualEffects;
using Zenject;

namespace Basis.App.Installers
{
    public sealed class AppInstaller : MonoInstaller
    {
        public bool RunExample;
    
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.BindInterfacesTo<MonoUpdater>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoader>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameObjectFinder>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<PrefabFactory>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ApplicationStatusHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
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