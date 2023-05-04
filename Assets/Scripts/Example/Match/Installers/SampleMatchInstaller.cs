using System.Collections.Generic;
using App.Assemblers;
using App.Fsm;
using Ecs;
using Example.App.Assemblers;
using Example.App.Services;
using Example.Match.Ecs;
using Utils;
using Zenject;

namespace Example.Match.Installers
{
    public sealed class SampleMatchInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
                Container.Resolve<SampleEcsService>(),
                Container.Resolve<SampleService>(), 
                Container.Resolve<SamplePhysicService>(), 
            });
        }
    }
}