namespace Basis.App.UI.Splashes
{
    public abstract class SplashViewModel : MonoViewModel
    {
        public abstract float Progress { get; set; }

        public virtual void Hide()
        {
        }
    }
}