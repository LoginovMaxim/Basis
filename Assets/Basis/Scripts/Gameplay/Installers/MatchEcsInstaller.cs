using Basis.Gameplay.Ecs;
using Basis.Gameplay.Ecs.Setups;
using BasisCore.Extensions;
using BasisCore.Services;
using BasisLeoEcsWrapper.Runtime;
using Zenject;

namespace Basis.Gameplay.Installers
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