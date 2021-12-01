using Utils;

namespace ViewModels
{
    public class LocalizationDataProvider : ILocalizationDataProvider
    {
        private const string LocalizationCsvFilePath = "LocalizationData - Meta";
        
        public LocalizationData LocalizationData => _localizationData;

        private LocalizationData _localizationData;

        public LocalizationDataProvider()
        {
            _localizationData = new LocalizationData()
            {
                Data = CSVReader.GetDictionary(LocalizationCsvFilePath)
            };
        }
    }
}