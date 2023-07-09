using Project.Match.Ecs;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchEcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MatchEcsWorld>().AsSingle().NonLazy();
        }
    }
}