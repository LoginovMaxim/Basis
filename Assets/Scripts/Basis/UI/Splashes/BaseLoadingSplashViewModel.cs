namespace Basis.UI.Splashes
{
    public abstract class BaseLoadingSplashViewModel : MonoViewModel
    {
        public abstract float Progress { get; set; }

        public abstract void Show();

        public abstract void Hide();
    }
}