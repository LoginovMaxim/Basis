using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchSignalsInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PauseMatchSampleSignal>();
            Container.DeclareSignal<UnpauseMatchSampleSignal>();
            Container.DeclareSignal<ExitMatchSampleSignal>();
        }
    }
}