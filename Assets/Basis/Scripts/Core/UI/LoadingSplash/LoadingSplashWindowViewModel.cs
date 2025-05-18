using BasisCore.Launchers;
using UniRx;

namespace Basis.Core.UI
{
    public sealed class LoadingSplashWindowViewModel : ILoadingSplashWindowViewModel
    {
        private readonly LoadingSplashModel _loadingSplashModel;
        private readonly ILauncherManager _launcherManager;
        
        public ReactiveProperty<float> Progress => _launcherManager.TotalProgress;

        public LoadingSplashWindowViewModel(LoadingSplashModel loadingSplashModel, ILauncherManager launcherManager)
        {
            _loadingSplashModel = loadingSplashModel;
            _launcherManager = launcherManager;
        }

        public void Init()
        {
        }

        public void Deinit()
        {
        }
    }
}