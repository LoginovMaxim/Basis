using BasisCore.Runtime.UI.Window;

namespace Project.Meta.UI.Main
{
    public sealed class MetaMainWindowController : WindowController<MetaMainWindowModel, MetaMainWindowView, MetaMainWindowBinder>
    {
        public MetaMainWindowController(MetaMainWindowModel windowModel) : base(windowModel)
        {
        }
    }
}