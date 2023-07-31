using Project.App.Configs;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Hiding
{
    public sealed class ToUpHidingScreenAnimator : MovementHidingScreenAnimator
    {
        public override ScreenHidingType ScreenHidingType => ScreenHidingType.ToUp;
        protected override Vector3 ToPosition => ScreenUtils.ScreenUpPosition;

        public ToUpHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}