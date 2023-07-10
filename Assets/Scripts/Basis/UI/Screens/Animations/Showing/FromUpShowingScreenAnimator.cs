using Project.App.Configs;
using UnityEngine;

namespace Basis.UI.Screens.Animations.Showing
{
    public sealed class FromUpShowingScreenAnimator : MovementShowingScreenAnimator
    {
        public override ScreenShowingType ScreenShowingType => ScreenShowingType.FromUp;
        protected override Vector3 FromPosition => ScreenUtils.ScreenUpPosition;
        
        public FromUpShowingScreenAnimator(IScreenAnimationConfig screenAnimationConfig) : base(screenAnimationConfig)
        {
        }
    }
}