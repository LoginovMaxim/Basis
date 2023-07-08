using System;
using UnityEngine;

namespace Basis.Data
{
    [Serializable] public class PersonalInfoStorageItem : StorageItem
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        
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
    }
}