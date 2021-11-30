using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerCurrency : IData
    {
        public event Action DataChanged;

        public int Soft
        {
            get => soft;
            set
            {
                if (soft == value)
                    return;

                soft = value;
                DataChanged?.Invoke();
            }
        }
        
        public int Hard
        {
            get => hard;
            set
            {
                if (hard == value)
                    return;

                hard = value;
                DataChanged?.Invoke();
            }
        }

        [SerializeField] private int soft;
        [SerializeField] private int hard;
    }
}