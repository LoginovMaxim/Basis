using Example.Meta.Signals;
using Zenject;

namespace Example.Installers
{
    public sealed class SampleMetaSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayMatchSampleSignal>();
        }
    }
}