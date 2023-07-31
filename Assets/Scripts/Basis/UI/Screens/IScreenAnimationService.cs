namespace Basis.UI.Screens
{
    public interface IScreenAnimationService
    {
        public void ShowingScreen(IScreenViewModel screenViewModel, ScreenShowingType screenShowingType);
        public void HidingScreen(IScreenViewModel screenViewModel, ScreenHidingType screenHidingType);
    }
}