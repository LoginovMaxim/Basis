using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerMeta : IData
    {
        public event Action DataChanged;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;
                DataChanged?.Invoke();
            }
        }
        
        public int Level
        {
            get => _level;
            set
            {
                if (_level == value)
                    return;

                _level = value;
                DataChanged?.Invoke();
            }
        }

        [SerializeField] private string _name;
        [SerializeField] private int _level;
    }
}