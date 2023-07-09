using System;
using Basis.Data;
using UnityEngine;

namespace Project.App.Data
{
    [Serializable]
    public class ProgressStorageItem : StorageItem
    {
        [SerializeField] private int _level;
        [SerializeField] private int _experience;
        
        public int Level
        {
            get => _level;
            set
            {
                if (_level == value)
                {
                    return;
                }

                _level = value;
                SaveUpdatedItem();
            }
        }
        
        public int Experience
        {
            get => _experience;
            set
            {
                if (_experience == value)
                {
                    return;
                }

                _experience = value;
                SaveUpdatedItem();
            }
        }
    }
}