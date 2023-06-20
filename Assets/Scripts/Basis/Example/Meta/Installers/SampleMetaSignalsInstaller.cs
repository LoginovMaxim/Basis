using Basis.Example.Meta.Signals;
using Zenject;

namespace Basis.Example.Meta.Installers
{
    public sealed class SampleMetaSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayMatchSampleSignal>();
        }
    }
}