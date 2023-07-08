using System;
using Basis.App.Pool;

namespace Basis.Example.Match.Views.Pools
{
    public sealed class SampleShipViewPool : ViewPool<SampleShipView>
    {
        protected override Type _viewObjectType => typeof(SampleShipView);
    }
}