using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.Services;
using Basis.Ecs;
using Basis.Example.App.Services;
using Basis.Example.Match.Assemblers;
using Basis.Example.Match.Ecs;
using Basis.Example.Match.Fsm.SampleMachine;
using Basis.Example.Match.Services;
using Basis.Utils;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SampleStateMachine>().AsSingle().NonLazy();

            Container.BindService<SampleService>(UpdateType.Update, true);

            // EcsSetups
            Container.BindInterfacesTo<SampleGameplayEcsSetup>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SampleEnvironmentEcsSetup>().AsSingle().NonLazy();
            
            var world = Container.BindEcsWorld<MainWorldBase>();
            Container.BindEcsService<SampleEcsService>(world, UpdateType.Update);
            
            // assembler parts
            var assemblerPats = new List<IAssemblerPart>
            {
                Container.BindAssemblerPart<SampleLoader>(),
            };

            // assembler
            Container.BindAssembler<SampleMatchAssembler>(assemblerPats);
        }
    }
}