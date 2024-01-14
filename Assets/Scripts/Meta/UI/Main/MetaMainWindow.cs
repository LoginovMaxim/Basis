using BasisCore.Runtime.UI.Window;

namespace Meta.UI.Main
{
    public sealed class MetaMainWindow : Window<MetaMainWindowModel, MetaMainWindowView, MetaMainWindowBinder>
    {
        public MetaMainWindow(MetaMainWindowModel windowModel) : base(windowModel)
        {
        }
    }
}