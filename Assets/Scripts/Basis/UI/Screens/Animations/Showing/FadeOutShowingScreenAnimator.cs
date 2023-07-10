using DG.Tweening;
using Project.App.Configs;

namespace Basis.UI.Screens.Animations.Showing
{
    public sealed class FadeOutShowingScreenAnimator : ShowingScreenAnimator
    {
        public override ScreenShowingType ScreenShowingType => ScreenShowingType.FadeOut;
        
        public FadeOutShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        protected override void ProcessShowing(IScreenViewModel screenViewModel)
        { 
            screenViewModel.CanvasGroup
                .DOFade(1, _showingFadeDuration)
                .SetEase(_showingFadeEase)
                .OnComplete(() => screenViewModel.CanvasGroup.interactable = true);
        }
    }
}