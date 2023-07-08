using System;
using Basis.App.Pool;

namespace Basis.Example.Match.Views.Pools
{
    public sealed class SampleSeaBlockViewPool : ViewPool<SampleSeaBlockView>
    {
        protected override Type _viewObjectType => typeof(SampleSeaBlockView);
    }
}