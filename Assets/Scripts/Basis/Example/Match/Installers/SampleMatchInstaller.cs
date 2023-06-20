using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.Fsm;
using Basis.Ecs;
using Basis.Example.App.Assemblers;
using Basis.Example.App.Fsm.SampleMachine;
using Basis.Example.App.Services;
using Basis.Example.Match.Ecs;
using Basis.Utils;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SampleStateMachine>().AsSingle().NonLazy();

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