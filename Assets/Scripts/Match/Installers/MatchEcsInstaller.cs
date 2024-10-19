using BasisCore.Runtime.Extensions;
using BasisCore.Runtime.Services;
using BasisLeoEcsWrapper.Runtime;
using Match.Ecs;
using Match.Ecs.Setups;
using Zenject;

namespace Match.Installers
{
    public sealed class MatchEcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EngineApi>().AsSingle().NonLazy();

            Container.BindInterfacesTo<MatchEcsWorldProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SyncViewMatchEcsSetup>().AsSingle().NonLazy();
            
            Container.BindService<MatchEcsService>(UpdateType.Update);
        }
    }
}