namespace Data
{
    public class PlayerProfile
    {
        private readonly DataStorage<PlayerData> _playerData;
        private readonly DataStorage<PlayerCurrency> _playerCurrency;
            
        public PlayerProfile(
            DataStorage<PlayerData> playerData,
            DataStorage<PlayerCurrency> playerCurrency)
        {
            _playerData = playerData;
            _playerCurrency = playerCurrency;
        }
    }
}