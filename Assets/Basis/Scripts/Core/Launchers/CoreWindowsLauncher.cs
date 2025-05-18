using System.Threading;
using Basis.Core.UI;
using BasisCore.Launchers;
using BasisCore.UI;
using Cysharp.Threading.Tasks;

namespace Basis.Core.Launchers
{
    public sealed class CoreWindowsLauncher : ILauncher
    {
        private readonly WindowFactory _windowFactory;
        private readonly ILoadingSplashWindowViewModel _loadingSplashWindowViewModel;

        public CoreWindowsLauncher(WindowFactory windowFactory, ILoadingSplashWindowViewModel loadingSplashWindowViewModel)
        {
            _windowFactory = windowFactory;
            _loadingSplashWindowViewModel = loadingSplashWindowViewModel;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            var loadingSplashWindow = await _windowFactory.CreateWindowAsync<LoadingSplashWindow, ILoadingSplashWindowViewModel>(
                    WindowNames.CoreWindows.LoadingSplash, _loadingSplashWindowViewModel, UILayerType.LoadingSplash);
            
            var windowManager = new WindowManager();
            WindowManager.Instance.RegisterWindow(WindowNames.CoreWindows.LoadingSplash, loadingSplashWindow);
            
            WindowManager.Instance.Open(WindowNames.CoreWindows.LoadingSplash);
        }
    }
}