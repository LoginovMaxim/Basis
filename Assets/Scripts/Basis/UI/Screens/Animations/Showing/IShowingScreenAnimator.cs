namespace Basis.UI.Screens.Animations.Showing
{
    public interface IShowingScreenAnimator : IScreenAnimator
    {
        public ScreenShowingType ScreenShowingType { get; }
    }
}