using Example.Meta.Signals;
using Zenject;

namespace Example.Meta.Installers
{
    public sealed class SampleMetaSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayMatchSampleSignal>();
        }
    }
}