using BasisCore.Runtime.UI.Screens;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreenBinder : BaseScreenBinder<MainScreenModel, MainScreenView>
    {
        public MainScreenBinder(MainScreenModel model, MainScreenView view) : base(model, view)
        {
            Bind(WindowView.PlayButton, WindowModel.PlayCommand);
            Bind(WindowView.ShopButton, WindowModel.ShopOpenCommand);
        }
    }
}