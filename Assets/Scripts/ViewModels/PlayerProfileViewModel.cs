using Localizations;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels
{
    [Binding]
    public class PlayerProfileViewModel : LocalizableViewModel
    {
        [Binding]
        public string LevelText
        {
            get => _levelText;
            set
            {
                if (_levelText == value)
                    return;

                _levelText = value;
                OnPropertyChanged(nameof(LevelText));
            }
        }
        
        [Binding]
        public string ExperienceText
        {
            get => _experienceText;
            set
            {
                if (_experienceText == value)
                    return;

                _experienceText = value;
                OnPropertyChanged(nameof(ExperienceText));
            }
        }
        
        [Binding]
        public string SoftCurrencyText
        {
            get => _softCurrencyText;
            set
            {
                if (_softCurrencyText == value)
                    return;

                _softCurrencyText = value;
                OnPropertyChanged(nameof(SoftCurrencyText));
            }
        }
        
        [Binding]
        public string HardCurrencyText
        {
            get => _hardCurrencyText;
            set
            {
                if (_hardCurrencyText == value)
                    return;

                _hardCurrencyText = value;
                OnPropertyChanged(nameof(HardCurrencyText));
            }
        }

        private string _levelText;
        private string _experienceText;
        private string _softCurrencyText;
        private string _hardCurrencyText;
        
        public class Factory : PlaceholderFactory<PlayerProfileViewModel> { }
    }
}