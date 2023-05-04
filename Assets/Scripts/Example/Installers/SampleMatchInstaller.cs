using System.Collections.Generic;
using App.Assemblers;
using App.Fsm;
using Ecs;
using Example.App.Assemblers;
using Example.App.Fsm.SampleMachine;
using Example.App.Services;
using Example.Match.Ecs;
using Example.Match.Ecs.Configs;
using Utils;
using Zenject;

namespace Example.Installers
{
    public sealed class SampleMatchInstaller : MonoInstaller
    {
        public MapConfig MapConfig;

        public override void InstallBindings()
        {
            // scriptable objects configs
            Container.BindInterfacesTo<MapConfig>().FromScriptableObject(MapConfig).AsSingle();

            //Container.Bind<SampleStateMachine>().AsSingle().NonLazy();

            // EcsSetups
            Container.BindInterfacesTo<SampleGameplayEcsSetup>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SampleEnvironmentEcsSetup>().AsSingle().NonLazy();

            var world = Container.BindEcsWorld<MainWorld>();
            
            // services
            Container.BindService<SampleService>(UpdateType.Update);
            Container.BindService<SamplePhysicService>(UpdateType.FixedUpdate);
            Container.BindEcsService<SampleEcsService>(world, UpdateType.Update);
            
            // assembler
            Container.BindAssembler<SampleAssembler>(new List<IAssemblerPart>
            {
                Container.Resolve<SampleService>(), 
                Container.Resolve<SamplePhysicService>(), 
                Container.Resolve<SampleEcsService>()
            });
        }
    }
}