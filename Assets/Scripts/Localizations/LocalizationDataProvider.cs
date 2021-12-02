using System.Threading.Tasks;
using Utils;

namespace ViewModels
{
    public class LocalizationDataProvider : ILocalizationDataProvider
    {
        private const string LocalizationAddressableKey = "LocalizationData - Meta";
        
        public LocalizationData LocalizationData => _localizationData;

        private LocalizationData _localizationData;
        
        public async Task Load()
        {
            var data = await CSVReader.GetDictionaryAsBundle(LocalizationAddressableKey);
            _localizationData = new LocalizationData {Data = data};
        }
    }
}