using DG.Tweening;
using Project.App.Configs;

namespace Basis.UI.Screens.Animations.Hiding
{
    public sealed class FadeInHidingScreenAnimator : HidingScreenAnimator
    {
        public override ScreenHidingType ScreenHidingType => ScreenHidingType.FadeIn;
        
        public FadeInHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        protected override void ProcessHiding(IScreenViewModel screenViewModel)
        {
            screenViewModel.CanvasGroup
                .DOFade(0, _hidingFadeDuration)
                .SetEase(_hidingFadeEase)
                .OnComplete(() => screenViewModel.SetActive(false));
        }
    }
}