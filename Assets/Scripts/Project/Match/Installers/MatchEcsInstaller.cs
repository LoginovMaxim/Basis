using Basis.Ecs;
using Basis.Services;
using Basis.Utils;
using Project.Match.Ecs;
using Project.Match.Ecs.Setups;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchEcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EngineApi>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<MatchEcsWorld>().AsSingle().NonLazy();

            Container.BindInterfacesTo<SyncViewMatchEcsSetup>().AsSingle().NonLazy();
            
            Container.BindService<MatchEcsService>(UpdateType.Update);
        }
    }
}