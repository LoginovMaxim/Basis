using DG.Tweening;

namespace Project.App.Configs
{
    public interface IScreenAnimationConfig
    {
        public float ShowingFadeDuration { get; }
        public Ease ShowingFadeEase { get; }
        public float HidingFadeDuration { get; }
        public Ease HidingFadeEase { get; }
        public float ShowingMoveDuration { get; }
        public Ease ShowingMoveEase { get; }
        public float HidingMoveDuration { get; }
        public Ease HidingMoveEase { get; }
    }
}