namespace App.Data
{
    public class PlayerProfile : IPlayerProfile
    {
        private readonly IDataStorage<PlayerProfileStorageItem> _playerProfileStorageItem;
        private readonly IDataStorage<PlayerCurrencyStorageItem> _playerCurrencyStorageItem;
        
        public PlayerProfile(
            IDataStorage<PlayerProfileStorageItem> playerProfileStorageItem,
            IDataStorage<PlayerCurrencyStorageItem> playerCurrencyStorageItem)
        {
            _playerProfileStorageItem = playerProfileStorageItem;
            _playerCurrencyStorageItem = playerCurrencyStorageItem;
        }

        #region IPlayerProfile

        string IPlayerProfile.Id => _playerProfileStorageItem.Data.Id;

        #endregion
    }
}