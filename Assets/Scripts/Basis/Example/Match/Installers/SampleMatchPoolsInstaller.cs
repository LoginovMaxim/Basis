using Basis.Example.Match.Views;
using Basis.Example.Match.Views.Pools;
using Basis.Utils;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchPoolsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindViewPool<SampleSeaBlockView, SampleSeaBlockViewPool>(3000);
            Container.BindViewPool<SampleShipView, SampleShipViewPool>(10);
        }
    }
}