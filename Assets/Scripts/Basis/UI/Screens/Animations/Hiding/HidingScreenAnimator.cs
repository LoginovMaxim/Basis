using DG.Tweening;
using Project.App.Configs;

namespace Basis.UI.Screens.Animations.Hiding
{
    public abstract class HidingScreenAnimator : ScreenAnimator, IHidingScreenAnimator
    {
        public abstract ScreenHidingType ScreenHidingType { get; }
        protected float _hidingFadeDuration => _screenAnimationConfig.HidingFadeDuration;
        protected Ease _hidingFadeEase => _screenAnimationConfig.HidingFadeEase;
        protected float _hidingMoveDuration => _screenAnimationConfig.HidingMoveDuration;
        protected Ease _hidingMoveEase => _screenAnimationConfig.HidingMoveEase;

        protected HidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        public override void Play(IScreenViewModel screenViewModel)
        {
            if (screenViewModel == null)
            {
                return;
            }
            
            screenViewModel.CanvasGroup.interactable = false;
            screenViewModel.CanvasGroup.alpha = 1;

            screenViewModel.RectTransform.DOKill();
            screenViewModel.CanvasGroup.DOKill();
            
            ProcessHiding(screenViewModel);
        }

        protected abstract void ProcessHiding(IScreenViewModel screenViewModel);
    }
}