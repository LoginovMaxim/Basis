using System;
using BasisCore.Runtime.Data;
using UnityEngine;

namespace Project.App.Data
{
    [Serializable] public class CurrencyStorageItem : StorageItem
    {
        [SerializeField] private int _soft;
        [SerializeField] private int _hard;
        
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
    }
}