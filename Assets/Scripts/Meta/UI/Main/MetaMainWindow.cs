using BasisCore.Runtime.UI;
using BasisCore.Runtime.UI.Window;

namespace Meta.UI.Main
{
    public sealed class MetaMainWindow : Window<MetaMainWindowModel, MetaMainWindowView>
    {
        public MetaMainWindow(MetaMainWindowModel windowModel, BindersFactory bindersFactory) : base(windowModel, bindersFactory)
        {
        }

        protected override void AddBinders()
        {
        }
    }
}