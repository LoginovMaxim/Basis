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
            
            /*_localizationData = new LocalizationData()
            {
                Data = new Dictionary<string, Dictionary<Language, string>>
                {
                    {"SoftCurrencyLabel", new Dictionary<Language, string>
                    {
                        {Language.EN, "Gold"},
                        {Language.RU, "Золото"},
                    }},
                    {"HardCurrencyLabel", new Dictionary<Language, string>
                    {
                        {Language.EN, "Crystals"},
                        {Language.RU, "Кристаллы"},
                    }},
                }
            };*/
        }
    }
}