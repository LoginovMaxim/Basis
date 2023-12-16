using BasisCore.Runtime.Reactive;
using BasisCore.Runtime.UI.Screens;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreenModel : BaseScreenModel
    {
        public ReactiveCommand PlayCommand { get; } = new();
        public ReactiveCommand ShopOpenCommand { get; } = new();
    }
}