using DG.Tweening;
using Project.App.Configs;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Showing
{
    public abstract class MovementShowingScreenAnimator : ShowingScreenAnimator
    {
        protected abstract Vector3 FromPosition { get; }

        protected MovementShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        protected override void ProcessShowing(IScreenViewModel screenViewModel)
        {
            screenViewModel.RectTransform.position = FromPosition;
            
            screenViewModel.RectTransform
                .DOMove(ScreenUtils.ScreenCenterPosition, _showingMoveDuration)
                .SetEase(_showingMoveEase);
            
            screenViewModel.CanvasGroup
                .DOFade(1, _showingFadeDuration)
                .SetEase(_showingFadeEase)
                .OnComplete(() => screenViewModel.CanvasGroup.interactable = true);
        }
    }
}