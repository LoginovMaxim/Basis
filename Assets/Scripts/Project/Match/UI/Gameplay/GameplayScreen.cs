using BasisCore.Runtime.UI.Screens;

namespace Project.Match.UI.Gameplay
{
    public sealed class GameplayScreen : BaseScreen<GameplayScreenViewModel>, IGameplayScreen
    {
        public GameplayScreen(
            IScreenAnimationService screenAnimationService, 
            GameplayScreenViewModel screenViewModel) : 
            base(screenAnimationService, screenViewModel)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }
    }
}