namespace Basis.UI.Splashes
{
    public abstract class SplashViewModel : MonoViewModel
    {
        public abstract float Progress { get; set; }

        public abstract void Show();

        public abstract void Hide();
    }
}