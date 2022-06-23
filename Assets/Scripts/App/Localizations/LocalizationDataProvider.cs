using System.Threading.Tasks;
using Utils;

namespace App.Localizations
{
    public class LocalizationDataProvider : ILocalizationDataProvider
    {
        public LocalizationData LocalizationData => _localizationData;

        private LocalizationData _localizationData;
        
        public async Task Load()
        {
            _localizationData = new LocalizationData { };
        }
    }
}