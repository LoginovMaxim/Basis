using Basis.UI.Signals;
using UnityWeld.Binding;
using Zenject;

namespace Basis.UI.Popups.ViewModels
{
    [Binding] public abstract class PopupViewModel : MonoViewModel
    {
        [Inject] private readonly SignalBus _signalBus;
        
        [Binding] public string Label
        {
            get => _label;
            set
            {
                if (_label == value)
                {
                    return;
                }

                _label = value;
                OnPropertyChanged(nameof(Label));
            }
        }
        
        [Binding] public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        
        [Binding] public string CloseButtonText
        {
            get => _closeButtonText;
            set
            {
                if (_closeButtonText == value)
                {
                    return;
                }

                _closeButtonText = value;
                OnPropertyChanged(nameof(CloseButtonText));
            }
        }
        
        [Binding] public string OkButtonText
        {
            get => _okButtonText;
            set
            {
                if (_okButtonText == value)
                {
                    return;
                }

                _okButtonText = value;
                OnPropertyChanged(nameof(OkButtonText));
            }
        }
        
        [Binding] public string CancelButtonText
        {
            get => _cancelButtonText;
            set
            {
                if (_cancelButtonText == value)
                {
                    return;
                }

                _cancelButtonText = value;
                OnPropertyChanged(nameof(CancelButtonText));
            }
        }

        private int _index;
        private string _label;
        private string _description;
        private string _closeButtonText;
        private string _okButtonText;
        private string _cancelButtonText;
        
        [Binding] public void OnCloseButtonClick()
        {
            OnClose();
        }

        [Binding] public void OnOkButtonClick()
        {
            OnOk();
        }
        
        [Binding] public void OnCancelButtonClick()
        {
            OnCancel();
        }

        protected virtual void OnClose() { }
        protected virtual void OnOk() { }
        protected virtual void OnCancel() { }

        protected void SetIndex(int index)
        {
            _index = index;
        }
        
        protected void SetLabel(string label)
        {
            Label = label;
        }

        protected void SetDescription(string description)
        {
            Description = description;
        }

        private void CallClosePopupSignal()
        {
            _signalBus.Fire(new ClosePopupSignal(_index));
        }
    }
}