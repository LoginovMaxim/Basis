using System.Threading;
using Basis.Core.UI;
using Basis.Meta.UI;
using BasisCore.Launchers;
using BasisCore.UI;
using Cysharp.Threading.Tasks;

namespace Basis.Meta.Launchers
{
    public class MetaWindowsLauncher : ILauncher
    {
        private readonly WindowFactory _windowFactory;
        private readonly IMetaMainWindowViewModel _metaMainWindowViewModel;
        private readonly IMetaSettingsPopupViewModel _metaSettingsPopupViewModel;

        public MetaWindowsLauncher(
            WindowFactory windowFactory, 
            IMetaMainWindowViewModel metaMainWindowViewModel, 
            IMetaSettingsPopupViewModel metaSettingsPopupViewModel)
        {
            _windowFactory = windowFactory;
            _metaMainWindowViewModel = metaMainWindowViewModel;
            _metaSettingsPopupViewModel = metaSettingsPopupViewModel;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            var metaMainWindow = await _windowFactory.CreateWindowAsync<MetaMainWindow, IMetaMainWindowViewModel>(
                WindowNames.MetaWindows.Main, _metaMainWindowViewModel, UILayerType.Main);
            
            var metaSettingsPopup = await _windowFactory.CreateWindowAsync<MetaSettingsPopup, IMetaSettingsPopupViewModel>(
                WindowNames.MetaWindows.Settings, _metaSettingsPopupViewModel, UILayerType.Popup);
            
            WindowManager.Instance.RegisterWindow(WindowNames.MetaWindows.Main, metaMainWindow);
            WindowManager.Instance.RegisterWindow(WindowNames.MetaWindows.Settings, metaSettingsPopup);
            
            WindowManager.Instance.Close(WindowNames.CoreWindows.LoadingSplash);
            WindowManager.Instance.Open(WindowNames.MetaWindows.Main);
        }
    }
}