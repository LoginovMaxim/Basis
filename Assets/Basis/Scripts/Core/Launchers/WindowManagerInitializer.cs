using System.Threading;
using BasisCore.Launchers;
using BasisCore.UI.WindowManager;
using Cysharp.Threading.Tasks;

namespace Basis.Core.Launchers
{
    public sealed class WindowManagerInitializer : ILauncher
    {
        private readonly WindowManagerSettings _windowManagerSettings;

        public WindowManagerInitializer(WindowManagerSettings windowManagerSettings)
        {
            _windowManagerSettings = windowManagerSettings;
        }

        public UniTask LaunchAsync(CancellationToken token)
        {
            WindowManager.Instance.Init(_windowManagerSettings);
            return UniTask.CompletedTask;
        }
    }
}