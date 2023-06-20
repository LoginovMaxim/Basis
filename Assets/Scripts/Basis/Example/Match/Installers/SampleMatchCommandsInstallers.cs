using Basis.Example.Match.Commands;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchCommandsInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PauseMatchSampleCommand>().AsSingle().NonLazy();
            Container.BindInterfacesTo<UnpauseMatchSampleCommand>().AsSingle().NonLazy();
        }
    }
}