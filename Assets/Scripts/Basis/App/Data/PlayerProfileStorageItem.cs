using System;
using UnityEngine;

namespace Basis.App.Data
{
    [Serializable] public class PlayerProfileStorageItem : StorageItem
    {
        public string Id
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                SaveUpdatedItem();
            }
        }
        
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                SaveUpdatedItem();
            }
        }
        
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

        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _experience;
    }
}