using Basis.Configs.UI;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Showing
{
    public sealed class FromDownShowingScreenAnimator : MovementShowingScreenAnimator
    {
        public override ScreenShowingType ScreenShowingType => ScreenShowingType.FromDown;
        protected override Vector3 FromPosition => ScreenUtils.ScreenDownPosition;
        
        public FromDownShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}