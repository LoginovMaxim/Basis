namespace App.UI.Splashes
{
    public abstract class Splash<TSplashViewModel> : ISplash where TSplashViewModel : SplashViewModel
    {
        protected TSplashViewModel _splashViewModel;

        protected Splash(TSplashViewModel splashViewModel)
        {
            _splashViewModel = splashViewModel;
        }

        public void Show()
        {
            _splashViewModel.SetActive(true);
        }

        public void Hide()
        {
            _splashViewModel.SetActive(false);
        }
    }
}