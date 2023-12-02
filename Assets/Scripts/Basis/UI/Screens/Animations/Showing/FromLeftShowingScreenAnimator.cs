using Basis.Configs.UI;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Showing
{
    public sealed class FromLeftShowingScreenAnimator : MovementShowingScreenAnimator
    {
        public override ScreenShowingType ScreenShowingType => ScreenShowingType.FromLeft;
        protected override Vector3 FromPosition => ScreenUtils.ScreenLeftPosition;
        
        public FromLeftShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}