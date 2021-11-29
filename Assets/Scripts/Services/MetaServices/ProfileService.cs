using Data;
using Monos;
using UnityEngine;

namespace Services.MetaServices
{
    public class ProfileService : UpdateService
    {
        private readonly DataStorage<PlayerMeta> _playerMeta;
        private readonly DataStorage<PlayerCurrency> _playerCurrency;
            
        public ProfileService(
            MonoUpdater monoUpdater,
            DataStorage<PlayerMeta> playerMeta,
            DataStorage<PlayerCurrency> playerCurrency) : base(monoUpdater)
        {
            _playerMeta = playerMeta;
            _playerCurrency = playerCurrency;
        }

        protected override void LaunchProcess()
        {
            Debug.Log($"Name {_playerMeta.Data.Name}");
            Debug.Log($"Level {_playerMeta.Data.Level}");
            
            Debug.Log($"Gold {_playerCurrency.Data.Gold}");
            Debug.Log($"Crystal {_playerCurrency.Data.Crystal}");
            
            Start();
        }

        protected override void ProcessRun()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _playerMeta.Data.Name = "Max";
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                _playerMeta.Data.Level = 2;
            }
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                _playerCurrency.Data.Gold = 50;
            }
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                _playerCurrency.Data.Crystal = 5;
            }
        }
    }
}