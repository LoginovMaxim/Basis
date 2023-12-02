using Basis.Configs.UI;
using DG.Tweening;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Hiding
{
    public abstract class MovementHidingScreenAnimator : HidingScreenAnimator
    {
        protected abstract Vector3 ToPosition { get; }

        protected MovementHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }

        protected override void ProcessHiding(IScreenViewModel screenViewModel)
        {
            screenViewModel.RectTransform
                .DOMove(ToPosition, _hidingMoveDuration)
                .SetEase(_hidingMoveEase)
                .OnComplete(() => screenViewModel.SetActive(false));
            
            screenViewModel.CanvasGroup.DOFade(0, _hidingFadeDuration).SetEase(_hidingFadeEase);
        }
    }
}