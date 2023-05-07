using System.Collections.Generic;
using App.Assemblers;
using App.Fsm;
using Ecs;
using Example.App.Assemblers;
using Example.App.Fsm.SampleMachine;
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
            Container.Bind<SampleStateMachine>().AsSingle().NonLazy();

            // EcsSetups
            Container.BindInterfacesTo<SampleGameplayEcsSetup>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SampleEnvironmentEcsSetup>().AsSingle().NonLazy();

            Container.BindService<SampleService>(UpdateType.Update);
            
            var world = Container.BindEcsWorld<MainWorld>();
            
            // assembler parts
            var assemblerPats = new List<IAssemblerPart>
            {
                Container.BindAssemblerPart<SampleLoader>(),
                Container.BindEcsAssemblerPart<SampleEcsService>(world, UpdateType.Update)
            };

            // assembler
            Container.BindAssembler<SampleAssembler>(assemblerPats);
        }
    }
}