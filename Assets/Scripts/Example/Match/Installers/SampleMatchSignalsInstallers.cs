using Example.Match.Signals;
using Zenject;

namespace Example.Match.Installers
{
    public sealed class SampleMatchSignalsInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PauseMatchSampleSignal>();
            Container.DeclareSignal<UnpauseMatchSampleSignal>();
        }
    }
}