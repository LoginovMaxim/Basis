using System.Collections.Generic;

namespace ViewModels
{
    public class LocalizationDataProvider : ILocalizationDataProvider
    {
        public LocalizationData LocalizationData => _localizationData;

        private LocalizationData _localizationData;

        public LocalizationDataProvider()
        {
            _localizationData = new LocalizationData()
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
            };
        }
    }
}