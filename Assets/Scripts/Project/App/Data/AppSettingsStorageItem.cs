using System;
using UnityEngine;

namespace Basis.Data
{
    [Serializable] public sealed class AppSettingsStorageItem : StorageItem
    {
        [SerializeField] private bool _isMuteMusic;
        [SerializeField] private bool _isMuteSounds;
        [SerializeField] private bool _isVibration;
        
        public bool IsMuteMusic
        {
            get => _isMuteMusic;
            set
            {
                if (_isMuteMusic == value)
                {
                    return;
                }

                _isMuteMusic = value;
                SaveUpdatedItem();
            }
        }
        
        public bool IsMuteSounds
        {
            get => _isMuteSounds;
            set
            {
                if (_isMuteSounds == value)
                {
                    return;
                }

                _isMuteSounds = value;
                SaveUpdatedItem();
            }
        }
        
        public bool IsVibration
        {
            get => _isVibration;
            set
            {
                if (_isVibration == value)
                {
                    return;
                }

                _isVibration = value;
                SaveUpdatedItem();
            }
        }
    }
}