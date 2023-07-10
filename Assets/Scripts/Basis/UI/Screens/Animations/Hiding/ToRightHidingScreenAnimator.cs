using Project.App.Configs;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Hiding
{
    public sealed class ToRightHidingScreenAnimator : MovementHidingScreenAnimator
    {
        public override ScreenHidingType ScreenHidingType => ScreenHidingType.ToRight;
        protected override Vector3 ToPosition => ScreenUtils.ScreenRightPosition;

        public ToRightHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}