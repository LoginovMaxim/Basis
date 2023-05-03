using System;
using UnityEngine;

namespace App.Data
{
    [Serializable] public class PlayerCurrency : IData
    {
        public event Action OnDataChanged;

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
                OnDataChanged?.Invoke();
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
                OnDataChanged?.Invoke();
            }
        }

        [SerializeField] private int _soft;
        [SerializeField] private int _hard;
    }
}