using Basis.Data;

namespace Project.App.Data
{
    public class ProfileProvider : IProfileProvider
    {
        private readonly IDataStorage<PersonalInfoStorageItem> _personalInfoStorageItem;
        private readonly IDataStorage<ProgressStorageItem> _progressStorageItem;
        private readonly IDataStorage<CurrencyStorageItem> _currencyStorageItem;

        public PersonalInfoStorageItem PersonalInfoData => _personalInfoStorageItem.Item;
        public ProgressStorageItem ProgressData => _progressStorageItem.Item;
        public CurrencyStorageItem CurrencyData => _currencyStorageItem.Item;

        public ProfileProvider(
            IDataStorage<PersonalInfoStorageItem> personalInfoStorageItem, 
            IDataStorage<ProgressStorageItem> progressStorageItem, 
            IDataStorage<CurrencyStorageItem> currencyStorageItem)
        {
            _personalInfoStorageItem = personalInfoStorageItem;
            _progressStorageItem = progressStorageItem;
            _currencyStorageItem = currencyStorageItem;
        }
    }
}