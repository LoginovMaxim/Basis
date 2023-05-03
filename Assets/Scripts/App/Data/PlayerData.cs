using System;
using UnityEngine;

namespace App.Data
{
    [Serializable] public class PlayerData : IData
    {
        public event Action OnDataChanged;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnDataChanged?.Invoke();
            }
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                OnDataChanged?.Invoke();
            }
        }
        
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level == value)
                {
                    return;
                }

                _level = value;
                OnDataChanged?.Invoke();
            }
        }
        
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (_experience == value)
                {
                    return;
                }

                _experience = value;
                OnDataChanged?.Invoke();
            }
        }

        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _experience;
    }
}