using Project.App.Configs;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Hiding
{
    public sealed class ToDownHidingScreenAnimator : MovementHidingScreenAnimator
    {
        public override ScreenHidingType ScreenHidingType => ScreenHidingType.ToDown;
        protected override Vector3 ToPosition => ScreenUtils.ScreenDownPosition;

        public ToDownHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}