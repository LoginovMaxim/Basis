using Basis.Configs.UI;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Hiding
{
    public sealed class ToLeftHidingScreenAnimator : MovementHidingScreenAnimator
    {
        public override ScreenHidingType ScreenHidingType => ScreenHidingType.ToLeft;
        protected override Vector3 ToPosition => ScreenUtils.ScreenLeftPosition;

        public ToLeftHidingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}