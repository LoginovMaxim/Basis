using System.Threading.Tasks;
using Assemblers;
using Monos;
using UnityEngine;

namespace ViewModels
{
    public class Localization : AssemblerPart
    {
        private readonly ViewModelFinder _viewModelFinder;
        private readonly ILocalizationDataProvider _localizationDataProvider;

        private Language _language = Language.EN;
        
        public Localization(
            ViewModelFinder viewModelFinder,
            ILocalizationDataProvider localizationDataProvider)
        {
            _viewModelFinder = viewModelFinder;
            _localizationDataProvider = localizationDataProvider;
        }

        public override async Task Launch()
        {
            await _localizationDataProvider.Load();
            
            var localizableViewModels = _viewModelFinder.GetViewModels<LocalizableViewModel>();

            foreach (var localizableViewModel in localizableViewModels)
            {
                localizableViewModel.TranslateViewModel(_localizationDataProvider.LocalizationData, _language);
            }
        }
    }
}