using System;
using UnityEngine;

namespace App.Data
{
    [Serializable] public class PlayerCurrencyStorageItem : StorageItem
    {
        public int Soft
        {
            get => _soft;
            set
            {
                if (_soft == value)
                {
                    return;
                }

                _soft = value;
                SaveUpdatedItem();
            }
        }
        
        public int Hard
        {
            get => _hard;
            set
            {
                if (_hard == value)
                {
                    return;
                }

                _hard = value;
                SaveUpdatedItem();
            }
        }

        [SerializeField] private int _soft;
        [SerializeField] private int _hard;
    }
}