using BasisCore.Runtime.UI.Screens;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreenBinder : BaseScreenBinder<MainScreenModel, MainScreenView>
    {
        public MainScreenBinder(MainScreenModel model, MainScreenView view) : base(model, view)
        {
            Bind(_view.PlayButton, _model.PlayCommand);
            Bind(_view.ShopButton, _model.ShopOpenCommand);
        }
    }
}