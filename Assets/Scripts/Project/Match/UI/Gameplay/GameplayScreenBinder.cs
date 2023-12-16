using BasisCore.Runtime.UI.Screens;

namespace Project.Match.UI.Gameplay
{
    public sealed class GameplayScreenBinder : BaseScreenBinder<GameplayScreenModel, GameplayScreenView>
    {
        public GameplayScreenBinder(GameplayScreenModel model, GameplayScreenView view) : base(model, view)
        {
            Bind(_view.QuitButton, _model.QuitCommand);
        }
    }
}