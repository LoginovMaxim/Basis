using System.Collections.Generic;
using App.Assemblers;
using App.Fsm;
using Ecs;
using Example.App.Assemblers;
using Example.App.Fsm.SampleMachine;
using Example.App.Services;
using Example.Ecs;
using Example.Ecs.Configs;
using Utils;
using Zenject;

namespace Example.Installers
{
    public sealed class SampleInstaller : MonoInstaller
    {
        public MapConfig MapConfig;

        public override void InstallBindings()
        {
            // scriptable objects configs
            Container.BindInterfacesTo<MapConfig>().FromScriptableObject(MapConfig).AsSingle();

            Container.Bind<SampleStateMachine>().AsSingle().NonLazy();
            
            // ecs worlds
            Container.Bind<MainWorld>().AsSingle().NonLazy();

            // EcsSetups
            Container.BindInterfacesTo<SampleGameplayEcsSetup>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SampleEnvironmentEcsSetup>().AsSingle().NonLazy();
            
            // services
            Container.BindService<SampleService>(UpdateType.Update | UpdateType.FixedUpdate);
            Container.BindEcsService<MainWorld, SampleEcsService>(UpdateType.Update);
            
            // assembler
            Container.BindAssembler<SampleAssembler>(new List<IAssemblerPart>
            {
                Container.Resolve<SampleService>(), 
                Container.Resolve<SampleEcsService>()
            });
        }
    }
}