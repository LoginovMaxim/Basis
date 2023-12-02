using Basis.Configs.UI;

namespace Basis.UI.Screens.Animations
{
    public abstract class ScreenAnimator : IScreenAnimator
    {
        protected readonly IScreenAnimationConfig _screenAnimationConfig;

        protected ScreenAnimator(IScreenAnimationConfig screenAnimationConfig)
        {
            _screenAnimationConfig = screenAnimationConfig;
        }

        public abstract void Play(IScreenViewModel screenViewModel);
    }
}