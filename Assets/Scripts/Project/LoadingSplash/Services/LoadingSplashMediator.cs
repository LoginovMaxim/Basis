using System;
using Basis.UI.Splashes;
using Project.App.UI.Splashes;

namespace Project.LoadingSplash.Services
{
    public sealed class LoadingSplashMediator : IDisposable
    {
        private readonly ISplash _splash;
        private readonly LoadingSplashViewModel _loadingSplashViewModel;

        public LoadingSplashMediator(ISplash splash, LoadingSplashViewModel loadingSplashViewModel)
        {
            _splash = splash;
            _loadingSplashViewModel = loadingSplashViewModel;

            _splash.OnLoadProgressChanged += HandleLoadProgress;
        }

        private void HandleLoadProgress(float progress)
        {
            _loadingSplashViewModel.Progress = progress;
        }

        public void Dispose()
        {
            _splash.OnLoadProgressChanged -= HandleLoadProgress;
        }
    }
}