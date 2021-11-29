using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerCurrency : IData
    {
        public event Action DataChanged;

        public int Gold
        {
            get => _gold;
            set
            {
                if (_gold == value)
                    return;

                _gold = value;
                DataChanged?.Invoke();
            }
        }
        
        public int Crystal
        {
            get => _crystal;
            set
            {
                if (_crystal == value)
                    return;

                _crystal = value;
                DataChanged?.Invoke();
            }
        }

        [SerializeField] private int _gold;
        [SerializeField] private int _crystal;
    }
}