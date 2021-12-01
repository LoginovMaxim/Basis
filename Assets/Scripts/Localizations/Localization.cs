using System.Threading.Tasks;
using Assemblers;
using Monos;

namespace ViewModels
{
    public class Localization : AssemblerPart
    {
        private readonly ViewModelFinder _viewModelFinder;
        private readonly ILocalizationDataProvider _localizationDataProvider;

        private Language _language = Language.RU;
        
        public Localization(
            ViewModelFinder viewModelFinder,
            ILocalizationDataProvider localizationDataProvider)
        {
            _viewModelFinder = viewModelFinder;
            _localizationDataProvider = localizationDataProvider;
        }

        protected override Task LaunchProcess()
        {
            var localizableViewModels = _viewModelFinder.GetViewModels<LocalizableViewModel>();

            foreach (var localizableViewModel in localizableViewModels)
            {
                localizableViewModel.TranslateViewModel(_localizationDataProvider.LocalizationData, _language);
            }
            
            return Task.CompletedTask;
        }
    }
}