using Basis.Example.Match.Views;
using Basis.Example.Match.Views.Pools;
using Basis.Utils;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchPoolsInstaller : MonoInstaller
    {
        public SampleSeaBlockView SampleSeaBlockView;
        public SampleShipView SampleShipView;
        
        public override void InstallBindings()
        {
            Container.BindViewPool<SampleSeaBlockView, SampleSeaBlockViewPool>(SampleSeaBlockView);
            Container.BindViewPool<SampleShipView, SampleShipViewPool>(SampleShipView);
        }
    }
}