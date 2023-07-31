using DG.Tweening;
using Project.App.Configs;

namespace Basis.UI.Screens.Animations.Showing
{
    public abstract class ShowingScreenAnimator : ScreenAnimator, IShowingScreenAnimator
    {
        public abstract ScreenShowingType ScreenShowingType { get; }
        protected float _showingFadeDuration => _screenAnimationConfig.ShowingFadeDuration;
        protected Ease _showingFadeEase => _screenAnimationConfig.ShowingFadeEase;
        protected float _showingMoveDuration => _screenAnimationConfig.ShowingMoveDuration;
        protected Ease _showingMoveEase => _screenAnimationConfig.ShowingMoveEase;

        protected ShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        public override void Play(IScreenViewModel screenViewModel)
        {
            if (screenViewModel == null)
            {
                return;
            }
            
            screenViewModel.SetActive(true);
            screenViewModel.CanvasGroup.alpha = 0;

            screenViewModel.RectTransform.DOKill();
            screenViewModel.CanvasGroup.DOKill();
            
            ProcessShowing(screenViewModel);
        }

        protected abstract void ProcessShowing(IScreenViewModel screenViewModel);
    }
}