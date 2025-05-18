using BasisCore.UI;
using UniRx;

namespace Basis.Meta.UI
{
    public interface IMetaSettingsPopupViewModel : IWindowViewModel
    {
        ReactiveCommand Close { get; }
    }
    
    public class MetaSettingsPopupViewModel : IMetaSettingsPopupViewModel
    {
        public ReactiveCommand Close { get; } = new();
        
        private readonly CompositeDisposable _subscribes = new();
        
        public void Init()
        {
            Close.Subscribe(HandleCloseButtonPressed).AddTo(_subscribes);
        }

        public void Deinit()
        {
            _subscribes.Clear();
        }

        private void HandleCloseButtonPressed(Unit _)
        {
            WindowManager.Instance.Back();
        }
    }
}