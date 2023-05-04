namespace App.UI.Splashes
{
    public sealed class AppSplash : Splash<AppSplashViewModel>, IAppSplash
    {
        public AppSplash(AppSplashViewModel splashViewModel) : base(splashViewModel)
        {
        }
    }
}