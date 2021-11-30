using UnityWeld.Binding;
using Zenject;

namespace ViewModels
{
    [Binding]
    public class PlayerProfileViewModel : LocalizableViewModel
    {
        [Binding]
        public string SoftCurrencyLabel
        {
            get => _softCurrencyLabel;
            set
            {
                if (_softCurrencyLabel == value)
                    return;

                _softCurrencyLabel = value;
                OnPropertyChanged(nameof(SoftCurrencyLabel));
            }
        }
        
        [Binding]
        public string HardCurrencyLabel
        {
            get => _hardCurrencyLabel;
            set
            {
                if (_hardCurrencyLabel == value)
                    return;

                _hardCurrencyLabel = value;
                OnPropertyChanged(nameof(HardCurrencyLabel));
            }
        }

        private string _softCurrencyLabel;
        private string _hardCurrencyLabel;
        
        public class Factory : PlaceholderFactory<PlayerProfileViewModel> { }
    }
}