namespace Basis.App.UI.Splashes
{
    public abstract class Splash<TSplashViewModel> : ISplash where TSplashViewModel : SplashViewModel
    {
        protected TSplashViewModel _splashViewModel;

        protected Splash(TSplashViewModel splashViewModel)
        {
            _splashViewModel = splashViewModel;
        }

        public virtual void Show()
        {
            _splashViewModel.SetActive(true);
        }

        public virtual void Hide()
        {
            _splashViewModel.Hide();
        }
    }
}