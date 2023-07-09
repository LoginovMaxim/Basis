using Basis.Data;

namespace Project.App.Data
{
    public class PlayerProfileProvider : IPlayerProfileProvider
    {
        private readonly IDataStorage<PersonalInfoStorageItem> _personalInfoData;
        private readonly IDataStorage<ProgressStorageItem> _progressData;
        private readonly IDataStorage<CurrencyStorageItem> _currencyData;
        
        public string Id => _personalInfoData.Item.Id;
        public string Name => _personalInfoData.Item.Name;
        public int Level => _progressData.Item.Level;
        public int Experience => _progressData.Item.Experience;
        public int Soft => _currencyData.Item.Soft;
        public int Hard => _currencyData.Item.Hard;

        public PlayerProfileProvider(
            IDataStorage<PersonalInfoStorageItem> personalInfoData, 
            IDataStorage<ProgressStorageItem> progressData, 
            IDataStorage<CurrencyStorageItem> currencyData)
        {
            _personalInfoData = personalInfoData;
            _progressData = progressData;
            _currencyData = currencyData;
        }
    }
}