using Basis.Configs.UI;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Showing
{
    public sealed class FromRightShowingScreenAnimator : MovementShowingScreenAnimator
    {
        public override ScreenShowingType ScreenShowingType => ScreenShowingType.FromRight;
        protected override Vector3 FromPosition => ScreenUtils.ScreenRightPosition;
        
        public FromRightShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}