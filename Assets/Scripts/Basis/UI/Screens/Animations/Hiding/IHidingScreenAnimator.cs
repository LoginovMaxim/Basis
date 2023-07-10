namespace Basis.UI.Screens.Animations.Hiding
{
    public interface IHidingScreenAnimator : IScreenAnimator
    {
        public ScreenHidingType ScreenHidingType { get; }
    }
}