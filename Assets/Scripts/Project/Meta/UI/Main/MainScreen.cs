using Basis.UI.Screens;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreen : BaseScreen<MainScreenViewModel>, IMainScreen
    {
        public MainScreen(
            IScreenAnimationService screenAnimationService, 
            MainScreenViewModel screenViewModel) : 
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