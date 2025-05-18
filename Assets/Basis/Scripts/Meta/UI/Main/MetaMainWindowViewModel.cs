using Basis.Core.UI;
using BasisCore.UI;
using UniRx;

namespace Basis.Meta.UI
{
    public interface IMetaMainWindowViewModel : IWindowViewModel
    {
        ReactiveCommand OpenSettings { get; }
    }
    
    public sealed class MetaMainWindowViewModel : IMetaMainWindowViewModel
    {
        public ReactiveCommand OpenSettings { get; } = new();
        
        private readonly CompositeDisposable _subscribes = new();
        
        public void Init()
        {
            OpenSettings.Subscribe(HandleCloseButtonPressed).AddTo(_subscribes);
        }

        public void Deinit()
        {
            _subscribes.Clear();
        }

        private void HandleCloseButtonPressed(Unit _)
        {
            WindowManager.Instance.Open(WindowNames.MetaWindows.Settings);
        }
    }
}